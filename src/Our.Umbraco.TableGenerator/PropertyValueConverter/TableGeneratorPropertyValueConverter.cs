﻿using System;
using Newtonsoft.Json;
using Our.Umbraco.TableGenerator.Models;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Core.PropertyEditors;

namespace Our.Umbraco.TableGenerator.PropertyValueConverter
{
	public class TableGeneratorPropertyValueConverter : PropertyValueConverterBase
	{
		public override Type GetPropertyValueType(IPublishedPropertyType propertyType) => typeof(TableData);
		public override PropertyCacheLevel GetPropertyCacheLevel(IPublishedPropertyType propertyType) => PropertyCacheLevel.Element;

		public override bool IsConverter(IPublishedPropertyType propertyType)
		{
			return propertyType.EditorAlias.Equals("Our.Umbraco.TableGenerator");
		}

		public override object ConvertSourceToIntermediate(IPublishedElement owner, IPublishedPropertyType propertyType, object source, bool preview)
		{
			return source?.ToString();
		}

		public override object ConvertIntermediateToObject(IPublishedElement owner, IPublishedPropertyType propertyType, PropertyCacheLevel referenceCacheLevel, object inter, bool preview)
		{
			return inter == null
				       ? new TableData()
				       : JsonConvert.DeserializeObject<TableData>(inter.ToString());
		}
	}
}