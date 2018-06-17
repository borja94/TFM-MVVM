namespace TFM_MVVM.Models
{

    public abstract class Dao
    {

        //protected BasicDataSource basicDataSource;

        //public Dao()
        //{
        //    basicDataSource = new BasicDataSource();
        //    basicDataSource.setDriverClassName("org.apache.derby.jdbc.ClientDriver");
        //    basicDataSource.setUsername("APP");
        //    basicDataSource.setPassword(null);
        //    basicDataSource.setUrl("jdbc:derby://localhost:1527/TFM");
        //}

        //protected void closeConnection(Connection connection)
        //{

        //    try
        //    {
        //        connection.close();
        //    }
        //    catch (SQLException ex)
        //    {
        //        Logger.getLogger(this.getClass().getName()).log(Level.SEVERE, null, ex);
        //    }
        //}

        //protected void closePreparedStatement(PreparedStatement preparedStatement)
        //{

        //    try
        //    {
        //        preparedStatement.close();
        //    }
        //    catch (SQLException ex)
        //    {
        //        Logger.getLogger(this.getClass().getName()).log(Level.SEVERE, null, ex);
        //    }
        //}

        //protected void closeResultSet(ResultSet resultSet)
        //{
        //    try
        //    {
        //        resultSet.close();
        //    }
        //    catch (SQLException ex)
        //    {
        //        Logger.getLogger(this.getClass().getName()).log(Level.SEVERE, null, ex);
        //    }
        //}
        //protected void closeStatement(Statement statement)
        //{

        //    try
        //    {
        //        statement.close();
        //    }
        //    catch (SQLException ex)
        //    {
        //        Logger.getLogger(this.getClass().getName()).log(Level.SEVERE, null, ex);
        //    }
        //}

    }
}
