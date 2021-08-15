using System;
using System.Collections.Generic;

namespace _937_Reorder_Data_in_Log_Files
{
    class Program
    {
        public static void Main()
        {
#if false
            string[] logs = new string[5];
            logs[0] = "dig1 8 1 5 1";
            logs[1] = "let1 art can";
            logs[2] = "dig2 3 6";
            logs[3] = "let2 own kit dig";
            logs[4] = "let3 art zero";
            ReorderLogFiles(logs);
#else
            
            string[] logs = new string[] { "j je", "b fjt", "7 zbr", "m le", "o 33" };
            ReorderLogFiles(logs);
#endif
        }

        public static string[] ReorderLogFiles(string[] logs)
        {
            // 1. distinguish letter-logs and digits-logs
            // 2. sorting letter-logs 
            // 3. sorting digits-logs
            // 4. compose both logs in a string array
            // 5. return string array

            string[] logs_arr = new string[logs.Length];

            List<string> letters_list = new List<string>();
            List<string> digits_list = new List<string>();

            // distinguish letter-logs and digits-logs
            for (int i = 0; i < logs.Length; i++)
            {
                string input_arr_str = logs[i].Split(' ', 2)[1];
                if (!int.TryParse(input_arr_str[0].ToString(), out int input_num))
                {
                    // this is letter-log
                    letters_list.Add(logs[i]);
                }
                else
                {
                    // this is digit-log
                    digits_list.Add(logs[i]);
                }
            }

            string[] letters_arr = letters_list.ToArray();
            string[] digits_arr = digits_list.ToArray();

            for (int i = 0; i < letters_arr.Length; i++)
            {
                if (letters_arr.Length < 2)
                {
                    logs_arr[i] = letters_arr[i];
                }
                else
                {
                    string[] splt_letter = letters_arr[i].Split(' ', 2);
                    for (int j = i + 1; j < letters_arr.Length; j++)
                    {
                        string[] splt_letter2 = letters_arr[j].Split(' ', 2);
                        if (string.Compare(splt_letter[1], splt_letter2[1]) < 0)
                        {
                            logs_arr[i] = string.Join(' ', splt_letter);
                            splt_letter = letters_arr[i].Split(' ', 2);
                            logs_arr[i + 1] = string.Join(' ', splt_letter2);
                        }
                        else
                        {
                            logs_arr[i] = string.Join(' ', splt_letter2);
                            splt_letter = letters_arr[j].Split(' ', 2);
                            logs_arr[i + 1] = string.Join(' ', splt_letter);
                        }
                    }
                }
            }

            
            for (int i = 0; i < digits_arr.Length; i++)
            {
                logs_arr[letters_arr.Length + i] = digits_arr[i];
            }

            return logs_arr;
        }
    }
}
