using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Tyuiu.AnisimovNV.Sprint7.Project.V7.Lib
{
    public class DataService
    {
        public string[,] LoadFromFile(string path)
        {
            if (!File.Exists(path)) return new string[0, 0];

            string[] lines = File.ReadAllLines(path);
            int rows = lines.Length;
            if (rows == 0) return new string[0, 0];

            int columns = lines[0].Split(';').Length;
            string[,] matrix = new string[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                string[] values = lines[i].Split(';');
                for (int j = 0; j < columns; j++)
                {
                    matrix[i, j] = j < values.Length ? values[j] : "";
                }
            }
            return matrix;
        }

        public void SaveToFile(string path, string[,] data)
        {
            int rows = data.GetLength(0);
            int cols = data.GetLength(1);

            using (StreamWriter writer = new StreamWriter(path))
            {
                for (int i = 0; i < rows; i++)
                {
                    string[] row = new string[cols];
                    for (int j = 0; j < cols; j++)
                    {
                        row[j] = data[i, j];
                    }
                    writer.WriteLine(string.Join(";", row));
                }
            }
        }

        public int[] SearchBySurname(string[,] data, string surname)
        {
            if (data.GetLength(0) <= 1) return new int[0];

            List<int> indexes = new List<int>();
            for (int i = 1; i < data.GetLength(0); i++)
            {
                if (data[i, 5].ToLower().Contains(surname.ToLower()))
                {
                    indexes.Add(i);
                }
            }
            return indexes.ToArray();
        }

        public (int withDebt, int withoutDebt) GetDebtStatistics(string[,] data)
        {
            int withDebt = 0, withoutDebt = 0;

            for (int i = 1; i < data.GetLength(0); i++)
            {
                if (bool.TryParse(data[i, 9], out bool debt))
                {
                    if (debt) withDebt++;
                    else withoutDebt++;
                }
            }
            return (withDebt, withoutDebt);
        }

        public object?[] GetStatistics(string[,] data)
        {
            throw new NotImplementedException();
        }
    }
}