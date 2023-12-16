namespace Demo;

public class Map
{
    private string[][] _map;
    private const string _land = "X";
    private const string _water = "O";
    public UInt32 Rows { get; private set; }
    public UInt32 Columns { get; private set; }
    
    public Map()
    {
       
    }

    public void PopulateMap(string[,] map, UInt32 rows, UInt32 columns)
    {
        if (rows < 2 && columns < 2)
            throw new ArgumentException("Minimum Rows and columns must be 2");
        
        _map = new string[rows][columns];
        Rows = rows;
        Columns = columns;
        for (int i = 0; i < rows; i++)
        {
            for (int j = i; j < columns-1; j++)
            {
                _map[i][j] = map[i][j];
            }
        }
    }

    public int a(UInt32 rowIndex)
    {
        int lastCol = 0;
        for (var i = 0; i < Columns; i++)
        {
            if (_map[rowIndex][i] == _land && _map[rowIndex][i] == _land)
            {
                
            }
        }
    }
    
    public int CalculateIsland()
    {
        int lastCol = 0;
        int lastRow = 0;
        int counter = 0;
        /*var island = new string[5, 5]
        {
            {"X", "X", "O", "O", "O"},
            {"X", "O", "O", "O", "O"},
            {"O", "O", "0", "X", "X"},
            {"X", "X", "O", "O", "X"},
            {"X", "X", "O", "O", "O"}
        };*/
        
        /*
         *  Pour rechercher le nombre d'iles on parcours la map en recherchant recursivement dans
         *  les coordonnées x,y de la map et tester si c'est un bout de land X ou water Y
         *  tant que les coordonnées x et y sont de type land on parcours la map selon l'axe X ou Y
         *  si les coordonnées x et y sont de type water on as découvert une île, on incrémente le nombre
         *  d'îles.
         */ 
        
        for (int i = 0; i < Rows; i++)
        {
            lastRow = i;
            for (int j = i; j < Columns-1; j++)
            {
                lastCol = j;
                if (_map[i][lastCol] == _land && _map[i][j] == _land)
                {
                    counter++;
                } 
            }
        }
    }
}