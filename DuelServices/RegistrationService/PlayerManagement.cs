namespace RegistrationService;

public class PlayerManagement
{
    public List<Player> Players { get; set; }

    public Player Registration() 
    {
        /*
            Anlegen eines neuen Spielers
            Name wird im Body der Request übergeben
            Id & Elo-Wert wird vom Service vergebn
        */
        Player p = new Player();
        return p;
    }
    public Player Update(int id)
    {
        /*
         * Aktualisiert einen vorhanden Spieler
         * Name & Elo-Wert können aktualisiert werden --> niemals die Id
         */
        Player p = new Player();
        return p;
    }

    public Player GetAllPlayer()
    {
        /*
         * liefert die Liste aller Spieler zurück
         */
        Player p = new Player();
        return p;
    }
}