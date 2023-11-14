using Mbk.Discord.Models;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text.Json;
using System.Xml;

namespace Mbk.Discord;

[AttributeUsage(AttributeTargets.Method)]
public class DiscordGameEvent : Attribute
{
    public string Name { get; set; }
    public string Identifier { get; set; }
    public string Description { get; set; }
    public IList<CustomOption>? CustomOptions { get; set; }

    public static string EventFile => Path.Combine(Discord.ConfigsPath, "discord_events.json");

    public class CustomOption
    {
        public string Name { get; set; }
        public object? Value { get; set; }
    }

    public DiscordGameEvent(string name, string identifier, string description, string[]? options = null)
    {
        Name = name;
        Identifier = identifier;
        Description = description;
        CustomOptions = options;
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
                            Console.WriteLine(customAttribute);

                            // Access properties or methods of the custom attribute
                            Console.WriteLine($"Method: {type.FullName}.{method.Name}, CustomAttribute Property: {customAttribute.Name}");

                            Console.WriteLine(Discord.Instance.GameEventList);
                            Console.WriteLine(Discord.Instance.GameEventList.Count);

                            if (!Discord.Instance.GameEventList.Any(x => x.Identifier == customAttribute.Identifier))
                            {
                                Discord.Instance.GameEventList?.Add(new()
                                {
                                    Identifier = customAttribute.Identifier,
                                    Name = customAttribute.Name,
                                    Description = customAttribute.Description
                                });
                                Save();
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