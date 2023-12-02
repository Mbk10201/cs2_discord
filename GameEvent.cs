using Mbk.Discord.Models;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text.Json;
using System.Xml;
using static Mbk.Discord.DiscordGameEvent;

namespace Mbk.Discord;

[AttributeUsage(AttributeTargets.Method)]
public class DiscordGameEvent : Attribute
{
    public string Name { get; set; }
    public string Identifier { get; set; }
    public string Description { get; set; }
    public IList<CustomOption>? CustomOptions { get; set; }

    public static string EventFile => Path.Combine(Discord.ConfigsPath, "discord_events.json");

    public DiscordGameEvent(string name, string identifier, string description, params string[] options)
    {
        Name = name;
        Identifier = identifier;
        Description = description;
        CustomOptions = new List<CustomOption>();

        foreach(var x in options)
        {
            CustomOptions.Add(new() { Name = x });
            Console.WriteLine($"[Discord] GameEvent {name} new option: {x}");
        }
    }

    public static GameEventSettings Get(string identifier) => Discord.Instance.GameEventList.Single(x => x.Identifier == identifier);

    public static void Initialize()
    {
        if (!File.Exists(EventFile))
            Save();
        else
            Load();
    }

    public static void Save()
    {
        Console.WriteLine($"[Discord] Saving {EventFile} ..");
        File.WriteAllText(EventFile, JsonSerializer.Serialize(Discord.Instance.GameEventList, new JsonSerializerOptions{WriteIndented = true}));
    }

    public static void Load()
    {
        Console.WriteLine($"[Discord] Loading {EventFile} ..");
        Discord.Instance.GameEventList = JsonSerializer.Deserialize<List<GameEventSettings>>(File.ReadAllText(EventFile));

        // Get the current assembly
        Assembly assembly = Assembly.GetExecutingAssembly();

        foreach (var e in AppDomain.CurrentDomain.GetAssemblies())
        {
            foreach (var type in e.GetTypes())
            {
                foreach (var method in type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
                {
                    // Check if method has attribute and if so, process that method.
                    // Get custom attributes of the method
                    object[] attributes = method.GetCustomAttributes(true);

                    foreach (object attribute in attributes)
                    {
                        // Check if the attribute is of the desired type
                        if (attribute is DiscordGameEvent customAttribute)
                        {

                            if (!Discord.Instance.GameEventList.Any(x => x.Identifier == customAttribute.Identifier))
                            {
                                Discord.Instance.GameEventList?.Add(new()
                                {
                                    Identifier = customAttribute.Identifier,
                                    Name = customAttribute.Name,
                                    Description = customAttribute.Description,
                                    CustomOptions = customAttribute.CustomOptions,
                                });
                                Save();
                            }
                            else
                            {
                                var selection = Discord.Instance.GameEventList.Single(x => x.Identifier == customAttribute.Identifier);

                                if(selection.CustomOptions.Count != customAttribute.CustomOptions.Count)
                                {
                                    foreach (var option in customAttribute.CustomOptions)
                                    {
                                        if(!selection.CustomOptions.Any(x => x.Name == option.Name))
                                        {
                                            selection.CustomOptions.Add(option);
                                            Save();
                                        }
                                    }
                                }
                            }

                            foreach(var item in Discord.Instance.GameEventList)
                            {
                                Console.WriteLine(item.Name);
                            }
                        }
                    }
                }
            }
        }
    }
}