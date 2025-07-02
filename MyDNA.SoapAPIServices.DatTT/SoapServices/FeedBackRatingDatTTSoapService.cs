using MyDNA.Services.DatTT;
using MyDNA.SoapAPIServices.DatTT.SoapModels;
using System.ServiceModel;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MyDNA.SoapAPIServices.DatTT.SoapServices
{
    [ServiceContract]
    public interface IFeedBackRatingDatTTSoapService 
    {
        [OperationContract]
        Task<List<FeedBackRatingDatTT>> GetFeedBackRatingDatTTAsync();
        [OperationContract]
        Task<FeedBackRatingDatTT> GetFeedBackRatingDatTTByIdAsync(int id);
        [OperationContract]
        Task<int> CreateFeedBackRatingDatTTAsync(FeedBackRatingDatTT feedBackRating);
        [OperationContract]
        Task<int> UpdateFeedBackRatingDatTTAsync(FeedBackRatingDatTT feedBackRating);
        [OperationContract]
        Task<int> DeleteFeedBackRatingDatTTAsync(int id);
    }
    public class FeedBackRatingDatTTSoapService : IFeedBackRatingDatTTSoapService
    {
        private readonly IServiceProviders _serviceProviders;
        public FeedBackRatingDatTTSoapService(IServiceProviders serviceProviders)
        {
            _serviceProviders = serviceProviders;
        }
        public async Task<List<FeedBackRatingDatTT>> GetFeedBackRatingDatTTAsync()
        {
            try
            {
                var feedBackRatingDatTTs = await _serviceProviders.FeedBackRatingDatTTService.GetAllAsync();


                var opt = new JsonSerializerOptions() { ReferenceHandler = ReferenceHandler.IgnoreCycles, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull };


                var feedBackRatingJsonString = JsonSerializer.Serialize(feedBackRatingDatTTs, opt);


                var result = JsonSerializer.Deserialize<List<FeedBackRatingDatTT>>(feedBackRatingJsonString, opt);

                return result;
            }
            catch (Exception ex) { }

            return new List<FeedBackRatingDatTT>();

            //throw new NotImplementedException();
        }

        public async Task<FeedBackRatingDatTT> GetFeedBackRatingDatTTByIdAsync(int feedBackRating)
        {
            try
            {
                var feedBackRatingDatTTs = await _serviceProviders.FeedBackRatingDatTTService.GetByIdAsync(feedBackRating);


                var opt = new JsonSerializerOptions() { ReferenceHandler = ReferenceHandler.IgnoreCycles, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull };


                var feedBackRatingJsonString = JsonSerializer.Serialize(feedBackRatingDatTTs, opt);


                var result = JsonSerializer.Deserialize<FeedBackRatingDatTT>(feedBackRatingJsonString, opt);

                return result;
            }
            catch (Exception ex) { }

            return new FeedBackRatingDatTT();

            //throw new NotImplementedException();
        }
        public async Task<int> CreateFeedBackRatingDatTTAsync(FeedBackRatingDatTT feedBackRatingDatTT)
        {
            try
            {

                var opt = new JsonSerializerOptions() { ReferenceHandler = ReferenceHandler.IgnoreCycles, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull };


                var feedBackRatingJsonString = JsonSerializer.Serialize(feedBackRatingDatTT, opt);


                var feedBackRatingDatTTs = JsonSerializer.Deserialize<MyDNA.Repositories.DatTT.Models.FeedBackRatingDatTT>(feedBackRatingJsonString, opt);

                var result = await _serviceProviders.FeedBackRatingDatTTService.CreateAsync(feedBackRatingDatTTs);

                return result;
            }
            catch (Exception ex) { }

            return 0;

            //throw new NotImplementedException();
        }
        public async Task<int> UpdateFeedBackRatingDatTTAsync(FeedBackRatingDatTT feedBackRatingDatTT)
        {
            try
            {

                var opt = new JsonSerializerOptions() { ReferenceHandler = ReferenceHandler.IgnoreCycles, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull };


                var feedBackRatingJsonString = JsonSerializer.Serialize(feedBackRatingDatTT, opt);


                var feedBackRatingDatTTs = JsonSerializer.Deserialize<MyDNA.Repositories.DatTT.Models.FeedBackRatingDatTT>(feedBackRatingJsonString, opt);

                var result = await _serviceProviders.FeedBackRatingDatTTService.UpdateAsync
                    (feedBackRatingDatTTs);

                return result;
            }
            catch (Exception ex) { }

            return 0;

            //throw new NotImplementedException();
        }
        public async Task<int> DeleteFeedBackRatingDatTTAsync(int feedBackRatingDatTT)
        {
            try
            {
                var result = await _serviceProviders.FeedBackRatingDatTTService.DeleteAsync(feedBackRatingDatTT);

                return result ? 1 : 0;
            }
            catch (Exception ex) { }

            return 0;

            //throw new NotImplementedException();
        }
    }
}
