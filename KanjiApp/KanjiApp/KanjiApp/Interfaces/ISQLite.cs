using SQLite;
namespace KanjiApp.Interfaces
{
	public interface ISQLite
	{
		SQLiteConnection GetConnection();
	}
}
