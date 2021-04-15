using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics.CodeAnalysis;


public static class Extensions
{

    public static bool lockSyntaxHighlighter = false;

    public static T[] AddItemToArray<T>(this T[] original, T itemToAdd)
    {
        if (original != null)
        {
            T[] finalArray = new T[original.Length + 1];
            for (int i = 0; i < original.Length; i++)
            {
                finalArray[i] = original[i];
            }
            finalArray[finalArray.Length - 1] = itemToAdd;
            return finalArray;
        }
        else
        {
            T[] finalArray = new T[1];
            finalArray[finalArray.Length - 1] = itemToAdd;
            return finalArray;
        }
    }

    public static T[] Clear<T>(this T[] original)
    {
        T[] finalArray = new T[0];
        return finalArray;
    }

    public static T[] RemoveAt<T>(this T[] original, int index)
    {
        if (original != null)
        {
            T[] finalArray = new T[original.Length - 1];
            int added = 0;
            for (int i = 0; i < original.Length; i++)
            {
                if (i != index)
                {
                    finalArray[added] = original[i];
                    added++;
                }
            }
            return finalArray;
        }
        else
        {
            T[] finalArray = new T[0];
            return finalArray;
        }
    }

    public static bool Contains<T>(this T[] original, string key)
    {
        bool contains = false;
        if (original != null)
        {
            for (int i = 0; i < original.Length; i++)
            {
                if (original[i].ToString() == key)
                {
                    contains = true;
                    break;
                }
            }
        }
        return contains;
    }

    public static T[] RemoveIfExists<T>(this T[] original, string key)
    {
        if (original != null)
        {
            T[] finalArray = new T[original.Length - 1];
            int added = 0;
            for (int i = 0; i < original.Length; i++)
            {
                if (original[i].ToString() != key)
                {
                    finalArray[added] = original[i];
                    added++;
                }
            }
            return finalArray;
        }
        else
        {
            T[] finalArray = new T[0];
            return finalArray;
        }
    }

    public static T[] Update<T>(this T[] original, T itemToAdd)
    {
        if (original != null)
        {
            T[] finalArray = new T[original.Length];
            for (int i = 0; i < original.Length; i++)
            {
                if (original[i].Equals(itemToAdd) == true)
                {
                    finalArray[i] = itemToAdd;
                }
                else
                {
                    finalArray[i] = original[i];
                }
            }
            return finalArray;
        }
        else
        {
            T[] finalArray = new T[0];
            return finalArray;
        }
    }

    public static string checksum<T>(this T[] original)
    {
        string concat = "";

        if (original != null)
        {
            for (int i = 0; i < original.Length; i++)
            {
                concat += original[i].ToString();
            }
            MD5 md5Hash = MD5.Create();
            return GetMd5Hash(md5Hash, concat);
        }
        else
        {
            return null;
        }
    }

    public static string checksum<T>(this T original)
    {

        if (original != null)
        {
            MD5 md5Hash = MD5.Create();
            return GetMd5Hash(md5Hash, original.ToString());
        }
        else
        {
            return null;
        }
    }

    public static bool arrEquals<T>(this T[] original, T[] comparison)
    {
        bool equals = true;
        if (original != null && comparison != null)
        {
            if (original.Length != comparison.Length)
            {
                equals = false;
            }
            else
            {
                for (int i = 0; i < original.Length; i++)
                {
                    if (original[i].ToString() != comparison[i].ToString())
                    {
                        equals = false;
                        break;
                    }
                }
            }
        }
        else
        {
            equals = false;
        }
        return equals;
    }

    public static string GetMd5Hash(MD5 md5Hash, string input)
    {
        byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
        StringBuilder sBuilder = new StringBuilder();
        for (int i = 0; i < data.Length; i++)
        {
            sBuilder.Append(data[i].ToString("x2"));
        }
        return sBuilder.ToString();
    }

    public static string[] ItemArray(this DataGridViewRow r)
    {
        string[] items = null;
        foreach (DataGridViewCell c in r.Cells)
        {
            items = items.AddItemToArray(c.Value.ToString());
        }
        return items;
    }

    public static byte[] CloneByteArray(this byte[] src)
    {
        if (src == null)
        {
            return null;
        }

        return (byte[])(src.Clone());
    }

}
