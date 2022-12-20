## Summary
Simple command line utility to generate text using given Liquid template and input object in json.

Usage:
```powershell
liquid.console --template "<liquid tempalte file including path>" --input "<json>"
```
Help: 
```powershell
 liquid.console --help
 ```
```
Description:
  generates output with given template and input

Usage:
  process [options]

Options:
  --template <template>  template file path
  --input <input>        input json
  --version              Show version information
  -?, -h, --help         Show help and usage information
```

Example:
Given following template file with name "template.liquid"
```text
"Hello {{ Firstname }} {{ Lastname }}"
```

```powershell
function escape($value){return $value.replace("""","\""");}
$object = @{Firstname="Random";Lastname="Person"};
liquid.console --template C:\temp\template.liquid --input "$(escape($object|ConvertTo-Json))"
#Output
#"Hello Random Person"
```