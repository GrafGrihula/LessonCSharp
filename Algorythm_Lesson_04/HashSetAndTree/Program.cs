﻿using System;
using System.Collections.Generic;

namespace HashSetAndArrayTest
{
    public class User
    {
        public string StringNames { get; set; }
        public override bool Equals(object obj)
        {
            var user = obj as User;
            if( user == null )
            {
                return false;
            }
            return StringNames == user.StringNames;
        }
        public override int GetHashCode()
        {
            int firtsNameHashCode = StringNames?.GetHashCode() ?? 0;
            return firtsNameHashCode;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var hashSet = new HashSet<User>();
            var user = new User();
            var searchUsser = new User();

            string randomString;
            var arrayList = new List<string>();
            var searchArrayList = new List<string>();

            string findStringr = "";

            for( double i = 0; i < 3; i++ )
            {
                randomString = Guid.NewGuid().ToString();

                user.StringNames = randomString;
                hashSet.Add( user );

                arrayList.Add( randomString );

                if( i == 0 )
                {
                    findStringr = randomString;

                    searchUsser.StringNames = findStringr;
                    searchArrayList.Add( findStringr );
                }

                Console.WriteLine( randomString );
            }
            

            Console.WriteLine( 
                $"HashSet: contains user {hashSet.Contains( user )}, " +
                $"contains searchUsser { hashSet.Contains( searchUsser )}" );

            Console.WriteLine( 
                $"Array: contains user {arrayList.Contains( findStringr )}, " +
                $"contains searchUsser { searchArrayList.Contains( findStringr )}" );
        }
    }
}
