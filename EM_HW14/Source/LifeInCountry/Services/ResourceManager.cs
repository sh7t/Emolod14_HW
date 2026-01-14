using EM_HW14.Source.Cities;
using System;
using System.Collections.Generic;

namespace EM_HW14.Source.Services
{
    public class ResourceManager
    {
        // fields
        protected Dictionary<ResourceType, int> _resources = new Dictionary<ResourceType, int>();

        // init
        public ResourceManager()
        {
            InitializeResources();
        }

        // get-set
        public Dictionary<ResourceType, int> resources
        {
            get { return _resources; }
        }
        public int happiness
        {
            get { return GetResourceQuantity(ResourceType.Happiness); }
        }
        public int food
        {
            get { return GetResourceQuantity(ResourceType.Food); }
        }
        public int tax
        {
            get { return GetResourceQuantity(ResourceType.Taxes); }
        }

        // funcs
        public int GetResourceQuantity(ResourceType type)
        {
            return _resources[type];
        }
        public void AddResource(ResourceType type, int quantity)
        {
            _resources[type] = Math.Max(0, _resources[type] + quantity);
        }

        private void InitializeResources()
        {
            foreach (ResourceType type in Enum.GetValues(typeof(ResourceType)))
            {
                _resources[type] = 0;
            }
        }
        public void MergeResources(Dictionary<ResourceType, int> resources)
        {
            foreach (KeyValuePair<ResourceType, int> resource in resources)
            {
                AddResource(resource.Key, resource.Value);
            }
        }
    }
}
