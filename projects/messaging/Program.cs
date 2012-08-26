using System;
using System.Linq;
using CommandLine;
using CommandLine.Text;
using messaging.Properties;

namespace messaging
{
    class Program
    {
        static void Main(string[] args) {
            var options = new Options();
            if (!CommandLineParser.Default.ParseArguments(args, options)) return;
            
            // Consume values here
            if (options.Verbose) Console.WriteLine("Filename: {0}", options.InputFile);
        }
    }

    internal sealed class Options : CommandLineOptionsBase
    {
        [Option("r", "read", Required = true,
          HelpText = "Input file to be processed.")]
        public string InputFile { get; set; }

        [Option("v", "verbose", DefaultValue = true,
          HelpText = "Prints all messages to standard output.")]
        public bool Verbose { get; set; }

        [HelpOption]
        public string GetUsage()
        {
            var help = new HelpText
            {
                Heading = new HeadingInfo(AssemblyInfo.Title, AssemblyInfo.Version),
                Copyright = new CopyrightInfo(AssemblyInfo.Author, 2012),
                AdditionalNewLineAfterOption = true,
                AddDashesToOption = true
            };
            HandleParsingErrorsInHelp(help);
            help.AddPreOptionsLine("<<license details here.>>");
            help.AddPreOptionsLine("Usage: CSharpTemplate -tSomeText --numeric 2012 -b");
            help.AddOptions(this);

            return help;
        }

        void HandleParsingErrorsInHelp(HelpText help)
        {
            if (!LastPostParsingState.Errors.Any()) return;

            var errors = help.RenderParsingErrorsText(this, 2); // indent with two spaces
            if (string.IsNullOrEmpty(errors)) return;

            help.AddPreOptionsLine(string.Concat(Environment.NewLine, "ERROR(S):"));
            help.AddPreOptionsLine(errors);
        }
    }
}
