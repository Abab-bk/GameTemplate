using Godot;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace OnReadyCs
{
    // Custom attribute to specify that a field should be initialized with a node fetched by its path when the scene is ready.
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class OnReadyAttribute : Attribute
    {
        // Property to store the path of the node to be fetched.
        public string NodePath { get; }

        // Constructor to set the node path.
        public OnReadyAttribute(string nodePath) => NodePath = nodePath;
    }

    // Extension methods for the Node class.
    public static class NodeExtensions
    {
        // Cache to hold FieldInfo objects for each class type
        private static readonly Dictionary<Type, List<FieldInfo>> FieldCache = new();
        
        // Cache to hold PropertyInfo objects for each class type
        private static readonly Dictionary<Type, List<PropertyInfo>> PropertyCache = new();

        // Cache to hold recovered nodes
        private static readonly Dictionary<(Node, string), Node> NodeCache = new();

        // Initializes fields in a Node instance that are marked with the OnReadyAttribute.
        public static void InitializeOnReadyFields(this Node instance)
        {
            Type instanceType = instance.GetType();

            // Initialize the FieldInfo cache for this type if it hasn't been done yet
            if (!FieldCache.ContainsKey(instanceType))
            {
                FieldCache[instanceType] = new List<FieldInfo>(
                    instanceType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                    .Where(field => Attribute.IsDefined(field, typeof(OnReadyAttribute)))
                );
            }

            // Iterate over each field.
            foreach (FieldInfo field in FieldCache[instanceType])
            {
                // Get the attribute.
                OnReadyAttribute attr = (OnReadyAttribute)Attribute.GetCustomAttribute(field, typeof(OnReadyAttribute));

                // Unique key for each combination of instance and node path
                var key = (instance, attr.NodePath);

                // Retrieve node from cache or fetch it if not cached
                if (!NodeCache.TryGetValue(key, out Node node))
                {
                    node = instance.GetNode(attr.NodePath);
                    NodeCache[key] = node;
                }

                // Set the value of the field to the fetched node.
                field.SetValue(instance, node);
            }

            // Initialize the PropertyInfo cache for this type if it hasn't been done yet
            if (!PropertyCache.ContainsKey(instanceType))
            {
                PropertyCache[instanceType] = new List<PropertyInfo>(
                    instanceType.GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(field => Attribute.IsDefined(field, typeof(OnReadyAttribute)))
                );
            }

            // Iterate over each property.
            foreach (PropertyInfo property in PropertyCache[instanceType])
            {
                // Get the attribute.
                OnReadyAttribute attr = (OnReadyAttribute)Attribute.GetCustomAttribute(property, typeof(OnReadyAttribute));

                // Unique key for each combination of instance and node path
                var key = (instance, attr.NodePath);

                // Retrieve node from cache or fetch it if not cached
                if (!NodeCache.TryGetValue(key, out Node node))
                {
                    node = instance.GetNode(attr.NodePath);
                    NodeCache[key] = node;
                }


                // Ensure the property has a setter
                if (property.SetMethod != null)
                {
                    property.SetValue(instance, node);
                }
                else
                {
                    GD.PrintErr($"The property {property.Name} in {instance.GetType().Name} has an [OnReady] attribute but lacks a 'setter'.");
                }
            }
        }

        // Method to clear all node caches
        public static void ClearAllNodeCaches()
        {
            NodeCache.Clear();
        }

        // Method to clear field and property caches
        public static void ClearReflectionCaches()
        {
            FieldCache.Clear();
            PropertyCache.Clear();
        }

        // Method to clear a specific node from cache
        public static void ClearNodeFromCache(Node instance, string nodePath)
        {
            var key = (instance, nodePath);
            NodeCache.Remove(key);
        }

        // Method to clear all caches (both node and reflection)
        public static void ClearAllCaches()
        {
            ClearAllNodeCaches();
            ClearReflectionCaches();
        }
    }
}