using System;
using System.Collections.Generic;

namespace Google_Unique_Email_Addresses
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] emails = new string[]{ "test.email+alex@leetcode.com", "test.e.mail+bob.cathy@leetcode.com", "testemail+david@lee.tcode.com" };
            Console.WriteLine(NumUniqueEmails(emails));
        }

        public static int NumUniqueEmails(string[] emails)
        {
            int output = 0;

            Dictionary<int, string> dic = new Dictionary<int, string>();
            for (int i = 0; i < emails.Length; i++)
            {
                string[] email_arr = emails[i].Split('@');
                string local_name = email_arr[0].ToLower();
                string domain_name = email_arr[1].ToLower();

                if (local_name.Contains('.'))
                {
                    // 이거 Char로 처리하면 어떻게 지워야 할지 모르겠다.
                    // String으로 억지로 처리함
                    local_name = local_name.Replace(".", "");
                }

                if (local_name.Contains('+'))
                {
                    local_name = local_name.Split('+')[0];
                }

                var filtered_email = local_name + '@' + domain_name;

                if (!dic.ContainsValue(filtered_email))
                {
                    dic.Add(output, filtered_email);
                    output++;
                }
            }

            return output;
        }
    }
}
