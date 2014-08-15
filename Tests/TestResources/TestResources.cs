namespace Tests.TestResources
{
    using NUnit.Framework;
    using Resources;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Resources;

    [TestFixture]
    public class TestResources
    {
        private List<string> englishResources;

        [SetUp]
        public void SetUp()
        {
            englishResources = GetResourcesKeys("en");
        }

        [TestCase("fr")]
        public void Resources_AllResources_SameKeysThanEnglishResources(string resourceNameToCompare)
        {
            // Act
            List<string> resourcesToCompare = this.GetResourcesKeys(resourceNameToCompare);

            // Assert
            var deficitInResourcesToCompare = englishResources.Except(resourcesToCompare).ToList();
            var surplusInResourcesToCompare = resourcesToCompare.Except(englishResources).ToList();

            // Assert
            Assert.IsEmpty(deficitInResourcesToCompare);
            Assert.IsEmpty(surplusInResourcesToCompare);
        }

        /// <summary>
        /// Get a list of keys for a resource
        /// </summary>
        private List<string> GetResourcesKeys(string resourceName)
        {
            ResourceSet resourcesSet = Resource.ResourceManager.GetResourceSet(new System.Globalization.CultureInfo(resourceName), true, true);
            IDictionaryEnumerator resourcesEnumerator = resourcesSet.GetEnumerator();

            var keys = new List<string>();

            while (resourcesEnumerator.MoveNext())
            {
                keys.Add((string)resourcesEnumerator.Key);
            }

            return keys;
        }
    }
}