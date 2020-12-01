using Models.Writings;
using System.Collections.Generic;


namespace Service.Abstractions
{
    public interface IWritingService
    {
        void Create(NewWritingModel model);
        IEnumerable<WritingModel> GetByUserId(int id);
        WritingModelWithComments GetById(int id);
        IEnumerable<WritingModel> GetAll();
        void Update(WritingModel model);
        void DeleteById(int id);
        void Publish(WritingPublishingModel model);
    }
}