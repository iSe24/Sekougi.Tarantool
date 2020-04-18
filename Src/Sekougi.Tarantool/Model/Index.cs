using Sekougi.Tarantool.Model.Enums;
using System.Collections.Generic;
using System;
using System.IO;
using System.Collections.ObjectModel;
using IndexData = System.ValueTuple<uint, uint, string, string, System.Collections.Generic.Dictionary<string, bool>, System.ValueTuple<int, string>[]>;



namespace Sekougi.Tarantool.Model
{
    public class Index
    {
        private Connection _connection;
        
        public uint Id { get; }
        public uint SpaceId { get; }
        public Space Space { get; private set; }
        public string Name { get; }
        public IndexTypeE Type { get; }
        public IReadOnlyDictionary<string, bool> Options { get; }
        public ValueTuple<int, string>[] KeyTypes { get; }


        public Index(IndexData indexData, Connection connection)
        {
            _connection = connection;

            SpaceId = indexData.Item1;
            Id = indexData.Item2;
            Name = indexData.Item3;
            Type = ModelUtils.GetIndexTypeFromString(indexData.Item4);
            Options = new ReadOnlyDictionary<string, bool>(indexData.Item5);
            KeyTypes = indexData.Item6;
        }

        internal void SetSpace(Space space)
        {
            if (SpaceId != space.Id)
                throw new InvalidDataException($"expected space with Id: {SpaceId} got space with Id {space.Id}");

            Space = space;
        }
    }
}