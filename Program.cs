using System.IO;

Menu();

static void Menu()
{
    Console.Clear();
    Console.WriteLine("O que deseja fazer ?");
    Console.WriteLine("1 - Abrir arquivo");
    Console.WriteLine("2 - Criar arquivo");
    Console.WriteLine("0 - Sair");
    short option = short.Parse(Console.ReadLine());

    switch(option)
    {
        case 0 : System.Environment.Exit(0); break;
        case 1 : Abrir(); break;
        case 2 : Editar(); break;
        default : Menu(); break;
    }
}
static void Abrir()
{
    Console.Clear();
    Console.WriteLine("Qual o caminho do arquivo?");
    string path = Console.ReadLine();

    using (var file = new StreamReader(path))
    {
        string text = file.ReadToEnd();
        Console.WriteLine(text);
    }

    Console.WriteLine("");
    Console.ReadLine();
    Menu();

}
static void Editar()
{
    Console.Clear();
    Console.WriteLine("Digite o seu texto abaixo (ESC para sair)");
    Console.WriteLine("---------");
    string text = "";

    do
    {
        text += Console.ReadLine();
        //+= will return all, what you already have and what the user will do.
        //if I use = he will change, but the += he will join.
        //Enviroment.NewLine, will add new line or line break /n
        text += Environment.NewLine;

    }
    while(Console.ReadKey().Key != ConsoleKey.Escape);

    Salvar(text);
}

static void Salvar(string text)
{
    Console.Clear();
    Console.WriteLine("Qual o caminho para salvar um arquivo?");
    var path = Console.ReadLine();

    using (var file = new StreamWriter(path))
    {
        file.Write(text);
    }

    Console.WriteLine($"Arquivo {path} salvo com sucesso!");
    Menu();
}
