using Fluid;
using Newtonsoft.Json;
using System.CommandLine;
using System.CommandLine.IO;
using System.CommandLine.Rendering;

var templateOption = new Option<string?>("--template", "template file path");
var inputOption = new Option<string?>("--input", "input json");
SystemConsole console = new SystemConsole();
var processTemplateCommand = new Command("process", "generates output with given template and input")
{
    templateOption,
    inputOption
};
processTemplateCommand.SetHandler((templateOption, inputOption) => ProcessTemplate(templateOption!, inputOption!,console), templateOption, inputOption);
await processTemplateCommand.InvokeAsync(args, console);

static void ProcessTemplate(string file, string json,IConsole console)
{
    ArgumentNullException.ThrowIfNull(file, nameof(file));
    ArgumentNullException.ThrowIfNull(json, nameof(json));

    if (!File.Exists(file))
    {
        throw new FileNotFoundException(file);
    }

    FluidParser templateParser = new FluidParser();
    var template = templateParser.Parse(File.ReadAllText(file));
    var input = JsonConvert.DeserializeObject(json);
    var context = new TemplateContext(input);
    var output = template.Render(context);
    console.Write(output);
}