using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
	Author: Lachlan Hopkins (lwlh)
    Edited (Heavily) by: Lindsay Wells
	Date: 2017
	Purpose: A simple fair randomised list with weights. Originally created for capstone project, now open for all to use.
	Contact: chickatrice.net, github.com/Lachee
*/

    /// <summary>
    /// A randomised list. It will store a collection of values with specified weights and provide functionallity to select randomly from the list.
    /// </summary>
    [System.Serializable]
    public class Rist<T> 
    {
        public List<ValueWeightPair<T>> list;
        private float _weight = 0;

        /// <summary>
        /// Number of elements currently in the table
        /// </summary>
        public int Count { get { return list.Count; } }

        /// <summary>
        /// The total tally of the weights. Use RecalculateWeights(); to update this value.
        /// </summary>
        public float Weight { get { return _weight; } }

        public Rist() { list = new List<ValueWeightPair<T>>(); }
        public Rist(int capacity) { list = new List<ValueWeightPair<T>>(capacity); }

        /// <summary>
        /// Clears the random table. 
        /// </summary>
        public void Clear()
        {
            list.Clear();
            _weight = 0;
        }

        /// <summary>
        /// Adds a new item with a specified weight to the table and increments the total weight.
        /// </summary>
        /// <param name="item">Item to add</param>
        /// <param name="weight">WEight this item has</param>
        public void Add(T item, float weight)
        {
            Add(new ValueWeightPair<T>() { Value = item, Weight = weight });
        }

        /// <summary>
        /// Adds a new value weight pair to the table and increments the total weight.
        /// </summary>
        /// <param name="pair">The item to be added</param>
        public void Add(ValueWeightPair<T> pair)
        {
            //We don't want to add anything that has no chance at all.
            //if (pair.Weight <= 0) return;

            list.Add(pair);
            _weight += pair.Weight;
        }


    /// <summary>
    /// Attempts to pick a random element from the table based off weighting, using Unity's built-in RNG.
    /// </summary>
    /// <param name="result">The random element that was fetched.</param>
    /// <returns>The randomly selected object</returns>
    public T Next()
    {
        return Next(Random.value);
    }

    /// <summary>
    /// Attempts to pick a random element from the table based off weighting.
    /// </summary>
    /// <param name="random">A random value between 0 and 1. This is done so System.Random or Unity.Random can be used.</param>
    /// <param name="result">The random element that was fetched.</param>
    /// <returns>The randomly selected object</returns>
    public T Next(float random)
        {
            float rand = random * Weight;
            for (int i = 0; i < list.Count; i++)
            {
                rand -= list[i].Weight;
                if (rand < 0)
                {
                    return list[i].Value;
                }
            }
            return default(T);//fail case
        }


        /// <summary>
        /// Recalculates the total weights
        /// </summary>
        public void RecalculateWeights()
        {
            _weight = 0;
            for (int i = 0; i < list.Count; i++)
                _weight += list[i].Weight;
        }
    
    }

[System.Serializable]
public struct ValueWeightPair<T>
{
    public T Value;
    public float Weight;
}

