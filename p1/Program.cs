using System.CommandLine;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;


string[] arrFiles =  { "cs", "java", "js", "html", "css", "c", "c++", "py", "jsx", "txt", "docx" };//מערך שפות אפשריות
var bundleCommand = new Command("bundle", "bundle code file");//זו פקודת הבאנדל

//יצירת האפשרויות
var bandelLanguate = new Option<string>(new[] { "--language","-l" }, "Enter language you want");
var bandelOutput = new Option<FileInfo>(new []{"--output","-o"}, "File path and name");
var bandelNote = new Option<bool>(new[] { "--note", "-n" }, "Write the source code as a comment in the file");
var bandelSort = new Option<bool>(new[] { "--sort", "-s" }, "The order of copying the code files");
var bandelRemove = new Option<bool>(new[] { "--remove", "-r" }, "delete empty lines");
var bandelAuthor = new Option<string>(new[]{"--author", "-a" }, "Registering the name of the creator of the file");

bundleCommand.AddOption(bandelLanguate);//מוסיפים את האפשרות לפקודת הבאנדל
bundleCommand.AddOption(bandelOutput);
bundleCommand.AddOption(bandelNote);
bundleCommand.AddOption(bandelSort);
bundleCommand.AddOption(bandelRemove);
bundleCommand.AddOption(bandelAuthor);

bundleCommand.SetHandler(( output, language, note, sort, remove, author) =>
{
    string directoryPath ="";// קביעת נתיב התקיה
    if (string.IsNullOrEmpty(directoryPath))
        directoryPath = Directory.GetCurrentDirectory();
    string fileName = Path.GetFileName(output.FullName);//שם הקובץ מתוך הנתיב המלא של הקובץ
    try
    {
        var f1 = File.Create(output.FullName);//יוצר תקיה חדשה
        Console.WriteLine("file was created");//מדפיס הודעה למשתמש שהקובץ נוצר
        f1.Close();
       var files = Directory.GetFiles(directoryPath);

        if (!string.IsNullOrEmpty(author))
        {
            using (StreamWriter sw = new StreamWriter(output.FullName))
            {
                sw.WriteLine(author);
            }
        }
        if (sort)
        {
            files = files.OrderBy(file => Path.GetExtension(file)).ToArray();
           
        }
        else
        {
            files = files.OrderBy(f => Path.GetFileName(f)).ToArray();
        }


        if (language.Equals("all"))
        {
            string extension;
            foreach (var file in files)
            {
                extension = Path.GetExtension(file);// מכניס לתוך המשתנה את הסיומת של הקובץ המסוים
                if (!string.IsNullOrEmpty(extension))
                    extension = extension.Substring(1);//מסיר את הנקודה
                if (Array.Exists(arrFiles, x => x.Equals(extension.ToLower())))
                {
                    string nameF = Path.GetFileName(file);
                    if (note && !nameF.Equals(fileName))
                    {

                        using (StreamWriter writer = new StreamWriter(output.FullName, append: true))
                        {
                            writer.WriteLine($"// Source Code : {file}");
                            string content = File.ReadAllText(file);
                            writer.WriteLine(content);
                            writer.WriteLine();
                        }
                    }
                }
            }
        }
        else
        {
            string[] languagesArr = language.Split(',', StringSplitOptions.RemoveEmptyEntries);
            bool languageFound = false;
            foreach (var lang in languagesArr)
            {
                if (Array.Exists(arrFiles, x => x.Equals(lang)))
                {
                    languageFound = true;

                    string extension;
                    foreach (var file in files)
                    {
                        extension = Path.GetExtension(file);
                        if (note && !string.IsNullOrEmpty(extension))
                            extension = extension.Substring(1);

                        if (extension.Equals(lang))
                        {
                            string nameF = Path.GetFileName(file);
                            if (!nameF.Equals(fileName))
                            {
                                using (StreamWriter writer = new StreamWriter(output.FullName, append: true))
                                {
                                    string content1 = File.ReadAllText(file);
                                    writer.WriteLine($"// Source Code : {file}");
                                    writer.WriteLine(content1);
                                    writer.WriteLine();
                                }
                            }

                        }

                    }
                }
     
                else

                  Console.WriteLine($"This language '{lang}' is forbidden.");
            }

            if (!languageFound)

                Console.WriteLine("No valid languages found in the provided input.");
        }
       if (remove)
       {
                string tempFile = "tempFile.txt";
                using (StreamReader reader = new StreamReader(output.FullName))
                using (StreamWriter writer = new StreamWriter(tempFile))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (!string.IsNullOrWhiteSpace(line))
                        {
                            writer.WriteLine(line); // כתיבה לשורות שנשארו
                        }
                    }

                }
              /*  Console.WriteLine("remove !!");    */ // מחיקת הקובץ הישן ותחלופה עם הקובץ החדש
                File.Delete(output.FullName);
                File.Move(tempFile, output.FullName);
       }  
    }
    

    catch (ArgumentException e)
    {
        Console.WriteLine($"ArgumentException: {e.Message}");
    }
    catch (DirectoryNotFoundException ex)
    {
        Console.WriteLine("didnt find the place");
    }
    catch (FileNotFoundException e)
    {
        Console.WriteLine("The specified output file does not exist");
    }
    catch (UnauthorizedAccessException e)
    {
        Console.WriteLine("no access");
    }
    catch (IOException ex)
    {
        Console.WriteLine($"IOException: {ex.Message}");
        Thread.Sleep(1000);
    }
    catch (Exception ex)
    {
        Console.WriteLine("Exception");
    }


}, bandelOutput, bandelLanguate, bandelNote, bandelSort, bandelRemove, bandelAuthor);
var creatersp = new Command("create-rsp", "create rsp");//זו פקודת הבאנדל

var rootCommand = new RootCommand("root command for file bundler");//יצירת פוקדת שורש
rootCommand.AddCommand(bundleCommand);
rootCommand.AddCommand(creatersp);  //מוסיפים לפקודת השורש את באנדל




// קובץ התגובה----

//פרמטרים נוספים לפקודה,מכניס כל פעם את הפלט למשתנה
creatersp.SetHandler(() =>
{
    Console.WriteLine("input commened as a parameter");//הכנס את הפקודה שברצונך להריץ
    string rspFileName = "create_rsp.rsp";
    Console.WriteLine("input a lunguage,if you would like all languags so type the word 'all'");
    string a = Console.ReadLine();
    Console.WriteLine("input file name");
    string b = Console.ReadLine();

    Console.WriteLine("do you want the code source as a note in file");
    string c = Console.ReadLine();
    if (c.Equals("true"))
        c = "-n";

    Console.WriteLine("the order of copying the code files:true/false");
    string d = Console.ReadLine();
    if (d.Equals("true"))
        d = "-s";

    Console.WriteLine("to remove empty lines");
    string e = Console.ReadLine();
    if (e.Equals("true"))
        e = "-r";

    Console.WriteLine("input the authors name");
    string f = Console.ReadLine();

        using (StreamWriter writer = new StreamWriter(rspFileName))//מכניסים את המשתנים לקובץ התגובה
        {
        //writer.WriteLine("p1 bundle ");

        if (!string.IsNullOrEmpty(a))//בודקים תקינות על כל משתנה,ולאחר מכן הוא כותב אותו בקובץ תגובה
                writer.WriteLine("-l " + a);
            if (!string.IsNullOrEmpty(b))
                writer.WriteLine("-o " + b);
            if (!string.IsNullOrEmpty(c))
                writer.WriteLine(c);
            if (!string.IsNullOrEmpty(d))
                writer.WriteLine(d);
            if (!string.IsNullOrEmpty(e))
                writer.WriteLine(e);
            if (!string.IsNullOrEmpty(f))
                writer.WriteLine("-a " + f);

        }
}
);

rootCommand.InvokeAsync(args);





