/*using System;
using System.Collections.Generic;
using System.Linq;
using AppRating.Controllers.Models;

namespace AppRating.Data
{
    public class DrivingServiceRepository
    {
        private static readonly List<DrivingService> _drivingServices = new List<DrivingService>();

        public DrivingService CreateEvaluation(int driverId, int rating)
        {
            var suggestedComment = GetSuggestedComment(rating);
            var evaluation = new DrivingService
            {
                DriverId = driverId,
                Rating = rating,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                SuggestedComment = suggestedComment
            };

            _drivingServices.Add(evaluation);
            return evaluation;
        }

        public DrivingService AddEvaluation(int driverId, DrivingServiceRequest request)
        {
            var evaluation = new DrivingService
            {
                DriverId = driverId,
                Rating = request.Rating,
                Comment = request.Comment,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            _drivingServices.Add(evaluation);
            return evaluation;
        }

        public void UpdateEvaluation(int evaluationId, DrivingServiceRequest request)
        {
            var drivingService = _drivingServices.FirstOrDefault(e => e.DrivingServiceId == evaluationId);

            if (drivingService != null)
            {
                drivingService.DriverId = request.DriverId;
                drivingService.Rating = request.Rating;
                drivingService.Comment = request.Comment;
                drivingService.UpdatedAt = DateTime.UtcNow;
            }
            else
            {
                throw new ArgumentException("Evaluation not found.");
            }
        }

        public void DeleteEvaluation(int evaluationId)
        {
            var drivingService = _drivingServices.FirstOrDefault(e => e.DrivingServiceId == evaluationId);

            if (drivingService != null)
            {
                _drivingServices.Remove(drivingService);
            }
            else
            {
                throw new ArgumentException("Evaluation not found.");
            }
        }

        private string GetSuggestedComment(int rating)
        {
            string[] comments = new string[]
            {
                "Quá tệ, cần cải thiện hơn.",
                "không hài lòng về chuyến đi.",
                "Tài xế vui vẻ, khá hài lòng.",
                "Tuyệt vời, đáng tin cậy.",
                "Hoàn hảo, an toàn và hài lòng!"
            };

            return comments[rating - 1];
        }
    }
}*/