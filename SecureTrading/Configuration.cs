﻿using System.Collections.Generic;

namespace SecureTrading
{
    enum ItemId
    {
        CannedVegetables = 2411,
        CannedMeat = 2412,
        AkuaBerry = 2413,
        Pizza = 2415,
    }

    public class Configuration : SharedCode.BaseConfiguration
    {
        public class SellLocation
        {
            public SharedCode.BoundingBoxInfo BoundingBox { get; set; }

            public Dictionary<int, double> ItemIdToUnitPrice { get; set; }

            public double DefaultPrice { get; set; }
        }

        public List<SellLocation> SellLocations { get; set; }

        public static void TestFormat(string filePath)
        {
            Configuration testee = new Configuration();

            testee.SellLocations = new List<SellLocation>();

            var location1 = new SellLocation();
            {
                var rect = new SharedCode.BoundingBoxInfo.Rect3() { pt0 = new SharedCode.BoundingBoxInfo.Vector3 { x = 0, y = 6, z = 9 }, pt1 = new SharedCode.BoundingBoxInfo.Vector3 { x = 1, y = 2.6F, z = 5 } };
                location1.BoundingBox = new SharedCode.BoundingBoxInfo { Playfield = "Akua2", Rect = rect };
                location1.ItemIdToUnitPrice = new Dictionary<int, double>();
                location1.ItemIdToUnitPrice.Add(2415, 1);
                location1.ItemIdToUnitPrice.Add(2413, 0.1);
            }
            testee.SellLocations.Add(location1);

            var location2 = new SellLocation();
            {
                var rect = new SharedCode.BoundingBoxInfo.Rect3() { pt0 = new SharedCode.BoundingBoxInfo.Vector3 { x = 0, y = 6, z = 9 }, pt1 = new SharedCode.BoundingBoxInfo.Vector3 { x = 1, y = 2.6F, z = 5 } };
                location2.BoundingBox = new SharedCode.BoundingBoxInfo { Playfield = "Akua2", Rect = rect };
                location2.ItemIdToUnitPrice = new Dictionary<int, double>();
                location2.ItemIdToUnitPrice.Add(2415, 1);
                location2.ItemIdToUnitPrice.Add(2413, 0.1);
            }
            testee.SellLocations.Add(location2);

            using (var writer = System.IO.File.CreateText(filePath))
            {
                var serializer = new YamlDotNet.Serialization.Serializer();

                serializer.Serialize(writer, testee);
            }
        }

        public Configuration()
        {
            //ItemIdToUnitPrice = new Dictionary<int, double>();
        }
    }
}
