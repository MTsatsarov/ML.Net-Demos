﻿// This file was auto-generated by ML.NET Model Builder. 
using Microsoft.ML;
using Microsoft.ML.Data;
using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
namespace CarPricePredictor
{
    public partial class CarPrediction
    {
        /// <summary>
        /// model input class for CarPrediction.
        /// </summary>
        #region model input class
        public class ModelInput
        {
            [ColumnName(@"brand")]
            public string Brand { get; set; }

            [ColumnName(@"model")]
            public string Model { get; set; }

            [ColumnName(@"year")]
            public float Year { get; set; }

            [ColumnName(@"price")]
            public float Price { get; set; }

            [ColumnName(@"fuelType")]
            public string FuelType { get; set; }

            [ColumnName(@"gearType")]
            public string GearType { get; set; }

            [ColumnName(@"totalKm")]
            public float TotalKm { get; set; }

            [ColumnName(@"HorsePowers")]
            public float HorsePowers { get; set; }

            [ColumnName(@"color")]
            public string Color { get; set; }

            [ColumnName(@"id")]
            public string Id { get; set; }

        }

        #endregion

        /// <summary>
        /// model output class for CarPrediction.
        /// </summary>
        #region model output class
        public class ModelOutput
        {
            [ColumnName(@"brand")]
            public float[] Brand { get; set; }

            [ColumnName(@"model")]
            public float[] Model { get; set; }

            [ColumnName(@"year")]
            public float Year { get; set; }

            [ColumnName(@"price")]
            public float Price { get; set; }

            [ColumnName(@"fuelType")]
            public float[] FuelType { get; set; }

            [ColumnName(@"gearType")]
            public float[] GearType { get; set; }

            [ColumnName(@"totalKm")]
            public float TotalKm { get; set; }

            [ColumnName(@"HorsePowers")]
            public float HorsePowers { get; set; }

            [ColumnName(@"color")]
            public float[] Color { get; set; }

            [ColumnName(@"id")]
            public string Id { get; set; }

            [ColumnName(@"Features")]
            public float[] Features { get; set; }

            [ColumnName(@"Score")]
            public float Score { get; set; }

        }

        #endregion

        private static string MLNetModelPath = Path.GetFullPath("CarPrediction.zip");

        public static readonly Lazy<PredictionEngine<ModelInput, ModelOutput>> PredictEngine = new Lazy<PredictionEngine<ModelInput, ModelOutput>>(() => CreatePredictEngine(), true);

        /// <summary>
        /// Use this method to predict on <see cref="ModelInput"/>.
        /// </summary>
        /// <param name="input">model input.</param>
        /// <returns><seealso cref=" ModelOutput"/></returns>
        public static ModelOutput Predict(ModelInput input)
        {
            var predEngine = PredictEngine.Value;
            return predEngine.Predict(input);
        }

        private static PredictionEngine<ModelInput, ModelOutput> CreatePredictEngine()
        {
            var mlContext = new MLContext();
            ITransformer mlModel = mlContext.Model.Load(MLNetModelPath, out var _);
            return mlContext.Model.CreatePredictionEngine<ModelInput, ModelOutput>(mlModel);
        }
    }
}