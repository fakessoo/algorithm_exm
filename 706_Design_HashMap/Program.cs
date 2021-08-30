using System;

namespace _706_Design_HashMap
{
    class Program
    {
        // There are two main issues that se should tackle, in order to design an efficient hashmap data structure:



        // 1. hash function design

        //      the purpose of hash function is to map a key value to an address in the storage space,
        //      similarly to the system that we assign a postcode to each mail address,
        //      As one can image, for a good hash function, it should map different keys 'evenly' across the storage space,
        //      so that we don't end up with the case that the majority of the keys are concentrated in a few spaces.

        // 2. collision handling

        //      essentially the hash function reduces the vast key space into a limited address space.
        //      As a result, there could be the case where two different keys are mapped to the same address,
        //      which is what we call 'collision'. Since the collision is inevitable,
        //      it is important that we have a strategy to handle the collision.

        //  Depending on how we deal with each of the above two issues, we could have various implementation of hashmap data structure.




        // 1. Modulo + Array

        // Intuition

        //  As one of the most intuitive implementations, we could adopt the 'modulo' operator as the hash function,
        //  since the key value is of integer type, in addition in order to minimize the potential collisions,
        //  it is advisable to use a prime number as the base of modulo, e.g. '2069'

        //  We organize the storage space as an 'array' where each element is indexed with the output value of the hash function.

        //  In case of 'collision', where two different keys are mapped to the same address, we use a 'bucket' to hold all the values.
        //  The bucket is a container that hold all the values that are assigned by the hash function.
        //  We could use either a 'LinkedList' or an 'Array' to implement the bucket data structure.

        //  Algorithm

        //  For each of the methods in hashmap data structure, namely get(), put() and remove(),
        //  it all bils down to the method to locate the value that is stored in hashmap, given the key.

        // This localization process can be done in two steps:

        //      For a given 'key' value, first we apply the hash function to generate a hash key,
        //      which corresponds to the address in our main storage.
        //      With this hash key, we would find the bucket where the value should be stored.

        //      Now that we found the bucket,
        //      we simply iterate through the bucket to check if the desired '<key, value>' pair does exist.


        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }


    }
}
