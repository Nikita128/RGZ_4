namespace RGZ_4
{
    public class Matrix
    {
        private double[,] elem;

        public double this[int i, int j]
        {
            get { return elem[i, j]; }
            set { elem[i, j] = value; }
        }

        public Matrix(int n, int m)
        {
            elem = new double[n, m];
            RowCount = n;
            ColumnCount = m;

            for (int i = 0; i < RowCount; i++)
                for (int j = 0; j < ColumnCount; j++)
                    elem[i, j] = 0;
        }

        public Matrix(double[] t)
        {
            elem = new double[t.Length, 1];
            RowCount = t.Length;
            ColumnCount = 1;

            for (int i = 0; i < RowCount; i++)
                for (int j = 0; j < ColumnCount; j++)
                    elem[i, j] = t[i];
        }

        public int RowCount { get; }
        public int ColumnCount { get; }

        public override bool Equals(object obj)
        {
            var temp = obj as Matrix;

            if (temp == null)
                return false;

            for (int i = 0; i < RowCount; i++)
                for (int j = 0; j < ColumnCount; j++)
                    if (elem[i, j] != temp.elem[i, j])
                        return false;

            return true;
        }

        public static bool operator !=(Matrix a, Matrix b)
        {
            return !(a == b);
        }

        public static bool operator ==(Matrix a, Matrix b)
        {
            for (int i = 0; i < a.RowCount; i++)
                for (int j = 0; j < a.ColumnCount; j++)
                    if (a.elem[i, j] != b.elem[i, j])
                        return false;

            return true;
        }

        public override int GetHashCode()
        {
            return GetHashCode();
        }

        public static Matrix operator +(Matrix a, Matrix b)
        {
            if (a.RowCount != b.RowCount || a.ColumnCount != b.ColumnCount)
                return null;

            Matrix temp = new Matrix(a.RowCount, a.ColumnCount);

            for (int i = 0; i < a.RowCount; i++)
                for (int j = 0; j < a.ColumnCount; j++)
                    temp.elem[i, j] = a.elem[i, j] + b.elem[i, j];

            return temp;
        }

        public static Matrix operator +(int x, Matrix b)
        {
            Matrix temp = new Matrix(b.RowCount, b.ColumnCount);

            for (int i = 0; i < b.RowCount; i++)
                for (int j = 0; j < b.ColumnCount; j++)
                    temp.elem[i, j] = b.elem[i, j] + x;

            return temp;
        }

        public static Matrix operator -(Matrix a, Matrix b)
        {
            if (a.RowCount != b.RowCount || a.ColumnCount != b.ColumnCount)
                return null;

            Matrix temp = new Matrix(a.RowCount, a.ColumnCount);

            for (int i = 0; i < a.RowCount; i++)
                for (int j = 0; j < a.ColumnCount; j++)
                    temp.elem[i, j] = a.elem[i, j] - b.elem[i, j];

            return temp;
        }

        public static Matrix operator *(Matrix a, double x)
        {
            Matrix temp = new Matrix(a.RowCount, a.ColumnCount);

            for (int i = 0; i < a.RowCount; i++)
                for (int j = 0; j < a.ColumnCount; j++)
                    temp.elem[i, j] = a.elem[i, j] * x;

            return temp;
        }

        public static Matrix operator *(double x, Matrix a)
        {
            return a * x;
        }

        public static Matrix operator /(Matrix a, double x)
        {
            Matrix temp = new Matrix(a.RowCount, a.ColumnCount);

            for (int i = 0; i < a.RowCount; i++)
                for (int j = 0; j < a.ColumnCount; j++)
                    temp.elem[i, j] = a.elem[i, j] / x;

            return temp;
        }

        public static Matrix operator *(Matrix a, Matrix b)
        {
            if (a.elem.Length == 1)
                return a[0, 0] * b;

            if (b.elem.Length == 1)
                return b[0, 0] * a;

            if (a.ColumnCount != b.RowCount)
                return null;

            Matrix temp = new Matrix(a.RowCount, b.ColumnCount);

            for (int i = 0; i < temp.RowCount; i++)
                for (int j = 0; j < temp.ColumnCount; j++)
                    for (int k = 0; k < a.ColumnCount; k++)
                        temp.elem[i, j] += a.elem[i, k] * b.elem[k, j];

            return temp;
        }

        public Matrix T()
        {
            Matrix temp = new Matrix(ColumnCount, RowCount);

            for (int i = 0; i < temp.RowCount; i++)
                for (int j = 0; j < temp.ColumnCount; j++)
                    temp.elem[i, j] = elem[j, i];

            return temp;
        }

        public static Matrix IdentityMatrix(int size)
        {
            Matrix temp = new Matrix(size, size);

            for (int i = 0; i < size; i++)
                temp.elem[i, i] = 1;

            return temp;
        }

        public double Determinant()
        {
            return elem[0, 0] * elem[1, 1] - elem[1, 0] * elem[0, 1];
        }

        /// <summary>
        /// Возвращает обратную матрицу только квадратных матриц второго ранга
        /// </summary>
        /// <returns></returns>
        public Matrix Inverse()
        {
            Matrix inverse = new Matrix(RowCount, ColumnCount);
            double det = Determinant();

            if (det == 0)
                return null;

            inverse.elem[0, 0] = elem[1, 1];
            inverse.elem[1, 1] = elem[0, 0];

            inverse.elem[0, 1] = -1 * elem[0, 1];
            inverse.elem[1, 0] = -1 * elem[1, 0];

            return inverse / det;
        }

        public static Matrix operator /(Matrix a, Matrix b)
        {
            if (b.RowCount == b.ColumnCount && b.RowCount == 1)
                if (b[0, 0] != 0)
                    return a / b.elem[0, 0];
                else
                    return a * 0;
            return a * b.Inverse();
        }

        public double[] ToArray()
        {
            var temp = new double[elem.Length];
            for (int i = 0; i < temp.Length; i++)
                temp[i] = elem[i, 0];

            return temp;
        }
    }

    public static class MatrixExtension
    {
        public static Matrix ToMatrix(this double x)
        {
            var temp = new Matrix(1, 1);
            temp[0, 0] = x;

            return temp;
        }
    }
}
