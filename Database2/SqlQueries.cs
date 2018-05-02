namespace RDZavia
{
    public class SqlQueries
    {
        public static decimal group;
        public static int page;
        public static string connectQuery = "server=localhost; user=root; database=RDZAviaDB; password=0000; Sslmode= none";
     
        public static string SSQuery = "SELECT  Where_, Whence_ , Date_ ,Rate_ ,Price_ FROM DataGridOne;";
       


        public static string insertQuery = "INSERT INTO Users(Login,Passwortd,Sex,UserName,SecondName,LastName,Data_) VALUES( @Login,@Passwortd,@Sex,@UserName,@SecondName,@LastName,@Data_)";

        public static string insertQuery1 = "INSERT INTO DataGridSecond(Login,Where_, Whence_ , Date_ ,Rate_ ,Price_) VALUES( @Login,@Where_, @Whence_ , @Date_ ,@Rate_ ,@Price_ )";
        public static string updateQuery = "UPDATE DataGridOne SET  Where_ = @Where_, Whence_=@Whence_,Date_=@Date_,Rate_  = @Rate_,Price_  = @Price_   WHERE ";
        public static string updateQuery1 = "UPDATE Users SET  UserName_ = @UserName, Passwortd=@Passwortd ";
        public static string deleteQuery = "DELETE FROM DataGridSecond WHERE id = @id";
        
    }
}
