using System;

namespace GameStore.DAL.Attributes
{
    class MongoCollectionAttribute:Attribute
    {
        public string CollectionName { get; set; }

        public MongoCollectionAttribute(string collectionName)
        {
            CollectionName = collectionName;
        }

    }
}
