using System.Collections.Generic;
using System.Linq;
using Application; // Stelle sicher, dass dein DbContext hier korrekt referenziert ist

namespace Application.Models
{
    class AdminPage
    {
        private readonly BarDbContext _context;

        // Konstruktor, um den DbContext zu initialisieren
        public AdminPage(BarDbContext context)
        {
            _context = context;
        }

        // Liste der Tische, die geladen und verwaltet werden
        public List<Table> Tables { get; set; }

        // Methode zum Laden der Tische aus der Datenbank
        public void LoadTables()
        {
            Tables = _context.Tables.ToList();
        }

        // Methode zum Hinzufügen eines neuen Tisches
        public void AddTable(string name, int x, int y)
        {
            var newTable = new Table { Name = name, X = x, Y = y };
            _context.Tables.Add(newTable);
            _context.SaveChanges();
            LoadTables(); // Aktualisiert die Liste nach dem Hinzufügen
        }

        // Methode zum Bearbeiten eines bestehenden Tisches
        public void EditTable(int id, string name, int x, int y)
        {
            var table = _context.Tables.FirstOrDefault(t => t.Id == id);
            if (table != null)
            {
                table.Name = name;
                table.X = x;
                table.Y = y;
                _context.SaveChanges();
                LoadTables(); // Aktualisiert die Liste nach dem Bearbeiten
            }
        }

        // Methode zum Löschen eines Tisches
        public void DeleteTable(int id)
        {
            var table = _context.Tables.FirstOrDefault(t => t.Id == id);
            if (table != null)
            {
                _context.Tables.Remove(table);
                _context.SaveChanges();
                LoadTables(); // Aktualisiert die Liste nach dem Löschen
            }
        }
    }
}
