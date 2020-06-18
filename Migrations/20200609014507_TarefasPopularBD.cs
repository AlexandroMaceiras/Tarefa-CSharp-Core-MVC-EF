using Microsoft.EntityFrameworkCore.Migrations;

namespace Tarefas.Migrations
{
    public partial class TarefasPopularBD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Tarefas(DataConclusao,EstaCompleta,Nome) Values ('20171010 08:00:00', 1, 'Tarefa 1')");
            migrationBuilder.Sql("INSERT INTO Tarefas(DataConclusao,EstaCompleta,Nome) Values ('20180111 08:00:00', 0, 'Tarefa 2')");
            migrationBuilder.Sql("INSERT INTO Tarefas(DataConclusao,EstaCompleta,Nome) Values ('20180205 08:00:00', 0, 'Tarefa 3')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Tarefas");
        }
    }
}
