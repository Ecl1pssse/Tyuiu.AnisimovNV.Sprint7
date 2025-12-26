using System;
using System.Collections.Generic;
using System.IO;
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
                    // Защита: если в строке меньше значений — пишем пустую строку
                    matrix[i, j] = (j < values.Length) ? values[j] : "";
                }
            }
            return matrix;
        }

        public void SaveToFile(string path, string[,] data)
        {
            int rows = data.GetLength(0);
            int cols = data.GetLength(1);
            string[] lines = new string[rows];

            for (int i = 0; i < rows; i++)
            {
                string[] row = new string[cols];
                for (int j = 0; j < cols; j++)
                {
                    row[j] = data[i, j];
                }
                lines[i] = string.Join(";", row);
            }

            File.WriteAllLines(path, lines); // Без кодировки — системная (Windows-1251)
        }

        public int[] SearchBySurname(string[,] data, string surname)
        {
            if (data.GetLength(0) <= 1) return Array.Empty<int>();
            List<int> indexes = new List<int>();
            for (int i = 1; i < data.GetLength(0); i++)
            {
                if (i < data.GetLength(0) && 5 < data.GetLength(1))
                {
                    if (data[i, 5].ToLower().Contains(surname.ToLower()))
                    {
                        indexes.Add(i);
                    }
                }
            }
            return indexes.ToArray();
        }

        public string[] GetStatistics(string[,] data)
        {
            if (data.GetLength(0) <= 1) return new string[] { "Нет данных" };

            int totalApartments = data.GetLength(0) - 1;
            double totalArea = 0, livingArea = 0;
            int totalRooms = 0, totalResidents = 0, debtCount = 0, childrenCount = 0;
            int maxRooms = 0, minRooms = int.MaxValue;

            for (int i = 1; i < data.GetLength(0); i++)
            {
                if (i >= data.GetLength(0)) continue;

                // Защита каждого столбца
                if (2 < data.GetLength(1) && double.TryParse(data[i, 2], out double area)) totalArea += area;
                if (3 < data.GetLength(1) && double.TryParse(data[i, 3], out double living)) livingArea += living;
                if (4 < data.GetLength(1) && int.TryParse(data[i, 4], out int rooms))
                {
                    totalRooms += rooms;
                    maxRooms = Math.Max(maxRooms, rooms);
                    minRooms = Math.Min(minRooms, rooms);
                }
                if (7 < data.GetLength(1) && int.TryParse(data[i, 7], out int residents)) totalResidents += residents;
                if (8 < data.GetLength(1) && int.TryParse(data[i, 8], out int children)) childrenCount += children;
                if (9 < data.GetLength(1) && bool.TryParse(data[i, 9], out bool hasDebt) && hasDebt) debtCount++;
            }
            if (minRooms == int.MaxValue) minRooms = 0;

            return new string[]
            {
                $"Всего квартир: {totalApartments}",
                $"Общая площадь: {totalArea:F2} м²",
                $"Жилая площадь: {livingArea:F2} м²",
                $"Средняя площадь: {(totalArea / totalApartments):F2} м²",
                $"Всего комнат: {totalRooms}",
                $"Макс комнат: {maxRooms}",
                $"Мин комнат: {minRooms}",
                $"Всего жильцов: {totalResidents}",
                $"Всего детей: {childrenCount}",
                $"С задолженностью: {debtCount}"
            };
        }

        public string[,] FilterByDebt(string[,] data, bool hasDebt)
        {
            if (data.GetLength(0) == 0) return new string[0, 0];
            List<int> rows = new List<int> { 0 };
            int cols = data.GetLength(1);

            for (int i = 1; i < data.GetLength(0); i++)
            {
                if (9 < cols && bool.TryParse(data[i, 9], out bool debt) && debt == hasDebt)
                {
                    rows.Add(i);
                }
            }

            string[,] result = new string[rows.Count, cols];
            for (int i = 0; i < rows.Count; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    result[i, j] = data[rows[i], j];
                }
            }
            return result;
        }

        public string[,] SortData(string[,] data, int col, bool asc = true)
        {
            if (data.GetLength(0) <= 2) return data;
            int rows = data.GetLength(0);
            int cols = data.GetLength(1);
            string[,] sorted = new string[rows, cols];


            for (int j = 0; j < cols; j++) sorted[0, j] = data[0, j];

            var rowList = new List<string[]>();
            for (int i = 1; i < rows; i++)
            {
                string[] r = new string[cols];
                for (int j = 0; j < cols; j++) r[j] = data[i, j];
                rowList.Add(r);
            }

            rowList = asc ? rowList.OrderBy(r => r[col]).ToList() : rowList.OrderByDescending(r => r[col]).ToList();

            for (int i = 0; i < rowList.Count; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    sorted[i + 1, j] = rowList[i][j];
                }
            }
            return sorted;
        }
    }
}