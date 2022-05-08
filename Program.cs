using efCoreMigrations;
using Spectre.Console;
using static Spectre.Console.AnsiConsole;

using var db = new BlogContext();

if (!db.Posts.Any())
{
    Write(new Markup("[green]Adding sample data...[/]"));
    db.AddRange(
        new Post { Title = "Intro to Migrations" },
        new Post { Title = "Migrations in Team Environments" },
        new Post { Title = "Advanced Migrations" });
    db.SaveChanges();
}

var table = new Table();
table.AddColumns(nameof(Post.Id), nameof(Post.Title), nameof(Post.Content));
WriteLine();
MarkupLine("[bold green]Posts[/]");
foreach (var post in db.Posts.ToList())
{
    // (string Id, string Title, string Content) parsedPost = (post.Id.ToString(), post.Title, post.Content);
    table.AddRow(post.Id.ToString(), post.Title, post.Content);
}

Write(table);
System.Console.ReadLine();