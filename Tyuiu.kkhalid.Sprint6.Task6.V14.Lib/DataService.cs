using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using tyuiu.cources.programming.interfaces.Sprint6;

namespace Tyuiu.Kkhalid.Sprint6.Task6.V14.Lib
{
    public class DataService : ISprint6Task6V14
    {
        public string CollectTextFromFile(string path)
        {
            try
            {
                // خواندن تمام محتوای فایل
                string fileContent = File.ReadAllText(path, Encoding.UTF8);

                // تقسیم متن به کلمات (با جداکننده‌های مختلف)
                char[] separators = new char[]
                {
                    ' ', '\t', '\n', '\r', ',', '.', ';', ':', '!', '?',
                    '(', ')', '[', ']', '{', '}', '"', '\'', '-', '—', '–'
                };

                string[] words = fileContent.Split(separators, StringSplitOptions.RemoveEmptyEntries);

                // فیلتر کلماتی که حرف 'z' دارند (حساس به بزرگی/کوچکی حروف)
                List<string> wordsWithZ = new List<string>();

                foreach (string word in words)
                {
                    if (word.IndexOf('z', StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        wordsWithZ.Add(word);
                    }
                }

                // تبدیل لیست به رشته با جداکننده خط جدید
                return string.Join(Environment.NewLine, wordsWithZ);
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка при обработке файла: {ex.Message}");
            }
        }
    }
}