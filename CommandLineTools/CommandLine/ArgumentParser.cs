using System;
using System.Linq;

using static CommandLineTools.CommandLine.Accept;
using static CommandLineTools.CommandLine.Create;

namespace CommandLineTools.CommandLine
{

    public static class ArgumentParser
    {
        public static readonly Parser Instance;

        public static readonly Command IntropGenCommand;

        //public static readonly Option DllOption;

        //public static readonly Option NamespaceNameOption;

        //public static readonly Option ClassNameOption;
        
        //public static readonly Option IncludeDirOption;

        //public static readonly Option ConfigPathOption;

        //public static readonly Option MacroOption;

        //public static readonly Option IncludeFileOption;

        //public static readonly Option OutputOption;

        public static readonly Option XmlPathOption;

        public static readonly Option OutputPathOption;

        public static readonly Option HelpOption;


        static ArgumentParser()
        {

            //DllOption = Option("-dll|--dll_export", "Full path to dll containing export methods", ExactlyOneArgument().With(name: "DLL_PATH"));

            //NamespaceNameOption = Option("-namespace|--namespace-name", "Output namespace name", ExactlyOneArgument().With(name: "NAMESPACE"));

            //ClassNameOption = Option("-class|--class-name", "Output class name", ExactlyOneArgument().With(name: "CLASS"));

            //IncludeDirOption = Option("-I|/I", "Include path", OneOrMoreArguments().With(name: "PATH"));

            //ConfigPathOption = Option("-xml|--config-xml", "Include path", ExactlyOneArgument().With(name: "PATH"));

            //MacroOption = Option("-D|/D", "Define a macro", OneOrMoreArguments().With(name: "VALUE"));

            //IncludeFileOption = Option("-include|/--include", "Include path", OneOrMoreArguments().With(name: "PATH"));

            //OutputOption = Option("-o|--out", "Output file location", ExactlyOneArgument().With(name: "OUTPUT"));

            XmlPathOption = Option("-x|--xml", "Input xml(s) location", ExactlyOneArgument().With(name: "INPUT"));

            OutputPathOption = Option("-o|--out", "Output cs location", ExactlyOneArgument().With(name: "OUTPUT"));

            HelpOption = Option("-h|--help|/?", "Show help information", NoArguments());
            
            //IntropGenCommand = Command("IntropGen", "Introp Generator", OneOrMoreArguments(), IncludeDirOption, ConfigPathOption, MacroOption, OutputOption, HelpOption);
            IntropGenCommand = Command("IntropGen", "Introp Generator", OneOrMoreArguments(), XmlPathOption, OutputPathOption, HelpOption);

            Instance = new Parser(IntropGenCommand);
        }

        public static bool HasHelpToken(AppliedOptionSet appliedOptionSet)
        {
            foreach (var appliedOption in appliedOptionSet)
            {
                if (appliedOption.Name == "help")
                {
                    return true;
                }

                if (HasHelpToken(appliedOption.AppliedOptions))
                {
                    return true;
                }
            }

            return false;
        }

        public static T IfOptionGetValue<T>(this AppliedOption appliedOption, string name, bool required = true)
        {
            if (appliedOption.HasOption(name))
            {
                return appliedOption[name].Value<T>();
            }

            if (required)
            {
                throw new Exception($"\"{name}\" argument is required.");
            }

            return default;
        }

        //public static Option VerbosityOption() => Option("-v|--verbosity",
        //                                                  "Set the verbosity level of the command. Allowed values are q[uiet], m[inimal], n[ormal], d[etailed], and diag[nostic]",
        //                                                  AnyOneOf("q[uiet]", "m[inimal]", "n[ormal]", "d[etailed]"));

        //public static Command Run() =>
        //    Command("run",
        //            "run",
        //            ILasm(),
        //            ILDasm(),
        //            VerbosityOption());

        //public static Command ILasm() =>
        //    Command("ilasm",
        //            "run ilasm",
        //            OneOrMoreArguments(),
        //            Option("-o|--output", "Output file in which to place built artifacts.", ExactlyOneArgument().With(name: "OUTPUT_FILE")),
        //            Option("-opt|--optimize", "", NoArguments().With(name: "OPTIMIZE")),
        //            Option("-res|--resource", "", ExactlyOneArgument().With(name: "RESOURCE")),
        //            Option("-key", "", ExactlyOneArgument().With(name: "KEY")),
        //            Option("-m64", "", NoArguments().With(name: "X64")),
        //            Option("-dll", "", NoArguments().With(name: "DLL")),
        //            Option("-debug", "", NoArguments().With(name: "DEBUG")),
        //            Option("-m|--method", "", ExactlyOneArgument().With(name: "METHOD")),
        //            VerbosityOption());

        //public static Command ILDasm() =>
        //    Command("ildasm",
        //            "run ildasm",
        //            OneOrMoreArguments(),
        //            Option("-o|--output", "Output directory in which to place built artifacts.", ExactlyOneArgument().With(name: "OUTPUT_DIR")),
        //            VerbosityOption());
    }

}
