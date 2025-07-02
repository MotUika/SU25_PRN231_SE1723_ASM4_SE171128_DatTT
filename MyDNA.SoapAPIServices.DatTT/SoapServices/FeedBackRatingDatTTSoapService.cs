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


                var cashDepositSlipJsonString = JsonSerializer.Serialize(feedBackRatingDatTTs, opt);


                var result = JsonSerializer.Deserialize<List<FeedBackRatingDatTT>>(cashDepositSlipJsonString, opt);

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


                var cashDepositSlipJsonString = JsonSerializer.Serialize(feedBackRatingDatTTs, opt);


                var result = JsonSerializer.Deserialize<FeedBackRatingDatTT>(cashDepositSlipJsonString, opt);

                return result;
            }
            catch (Exception ex) { }

            return new FeedBackRatingDatTT();

            //throw new NotImplementedException();
        }

        public Task<int> DeleteFeedBackRatingDatTTAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateFeedBackRatingDatTTAsync(FeedBackRatingDatTT feedBackRating)
        {
            throw new NotImplementedException();
        }

        public Task<int> CreateFeedBackRatingDatTTAsync(FeedBackRatingDatTT feedBackRating)
        {
            throw new NotImplementedException();
        }
    }
}
