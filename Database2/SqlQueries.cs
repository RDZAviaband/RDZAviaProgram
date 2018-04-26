namespace Database2
{
    public class SqlQueries
    {
        public static decimal group;
        public static int page;
        public static string connectQuery = "server=localhost; user=root; database=RDZAviaDB; password=0000; Sslmode= none";
     
        public static string SSQuery = "SELECT id, Where_, Whence_ , Date_ ,Rate_ ,Price_ FROM DataGridOne;";
       // public static string SLQuery = 
       // public static string PagesQuery = "SELECT id, Where_, Whence_ , Date_ ,Rate_ ,Price_ FROM DataGridOne WHERE id > {0} * {1}  AND id <= {0} * {1} + {1};";
  
        public static string insertQuery = "INSERT INTO DataGridOne(Where_, Whence_ , Date_ ,Rate_ ,Price_) VALUES( @Where_, @Whence_ ,@Date_ ,@Rate_ ,@Price_)";
        public static string updateQuery = "UPDATE DataGridOne SET  Where_ = @Where_, Whence_=@Whence_,Date_=@Date_,Rate_  = @Rate_,Price_  = @Price_   WHERE ";
        public static string deleteQuery = "DELETE FROM DataGridOne WHERE id = @id";
        
    }
}
