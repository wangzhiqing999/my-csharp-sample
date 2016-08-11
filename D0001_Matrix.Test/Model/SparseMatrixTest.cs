using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;



namespace D0001_Matrix.Model
{


    [TestFixture]
    public class SparseMatrixTest : MatrixTest
    {

        protected override Matrix<int> CreateNewTestMatrix(int x, int y)
        {
            return new SparseMatrix<int>(x, y);
        }

    }

}
