using System;
namespace MatrixLibrary
{
   
    public interface IMatrix
    {
        int Row { get; set; }
        int Column { get; set; }
        double[,] Array { get; set; }  

    }
}
