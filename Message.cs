﻿//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ConsoleApplication1
//{
//    class Message
//    {
//        using System;
//using System.Collections;
//using System.Collections.Generic;


//// To execute C#, please define "static void Main" on a class
//// named Solution.

//class Solution
//{
//    static Dictionary<string, string> store = new Dictionary<string, string>();
//    static Dictionary<string, Dictionary<string, string>> newMessages = new Dictionary<string, Dictionary<string, string>>();
    
//    static void Main(string[] args)
//    {
//        Add("1", "first message", "1");
//        Add("2", "second message", "2");
//        foreach(string s in GetMessages())
//        {
//            Console.WriteLine(s);
//        }
//        foreach(string s in GetNewMessages("1"))
//        {
//            Console.WriteLine(s);
//        }
//        foreach(string s in GetNewMessages("1"))
//        {
//            Console.WriteLine(s);
//        }
            
//    }
    
//    static public bool Add(string id, string mes, string appId)
//    {     
        
//        if(!store.ContainsKey((id)))
//        {
//            store.Add(id, mes);    
//            Dictionary<string, string> temp = new Dictionary<string, string>();
//            temp.Add(id, mes);
//            newMessages.Add(appId, temp);
//            return true;
//        }
//        else
//            return false;
//    }
    
//    static public List<string> GetMessages()
//    {
//        List<string> messages = new List<string>();
//        foreach(string key in store.Keys)
//        {
//            messages.Add(store[key]);
//        }
//        return messages;
//    }
    
//    static public List<string> GetNewMessages(string appId)
//    {
//        List<string> messages = new List<string>();
//        Dictionary<string, string> temp = newMessages[appId];
//        foreach(string key in temp.Keys)
//        {
//            messages.Add(temp[key]);
//        }
//        newMessages[appId].Clear();
//        return messages;
//    }
    
    
//}

//// Message {
////    String id; // A unique identifier for the message, generated by the client.
////    String text; // The content of the message, e.g. “Hi!” or “Thanks for the coffee”
//// }

//// 1) create a new message
//// 2) get all messages
//    }
//}
