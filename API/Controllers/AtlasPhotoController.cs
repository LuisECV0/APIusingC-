using API.Data;
using API.Models;
using API.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtlasPhotoController : Controller
    {
        private readonly AppDbContext _context;
        private ResponseDto _response;

        public AtlasPhotoController(AppDbContext context)
        {
            _context = context;
            _response = new ResponseDto { IsSuccess = true }; // Inicializar IsSuccess como true
        }

        [HttpGet("GetPhotos")]
        public ResponseDto GetPhotos()
        {
            try
            {
                IEnumerable<AtlasPhoto> photos = _context.Photos.ToList();
                //var photos = _context.Photos.FirstOrDefault(p => p.Id == id);
                _response.Data = photos;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpGet("GetPhotoById/{id}")]
        public ResponseDto GetPhotoById(int id)
        {
            try
            {
                var photos = _context.Photos.FirstOrDefault(p => p.Id == id);
                _response.Data = photos;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpGet("GetPhotoByTitle/{title}")]
        public ResponseDto GetPhotoByTitle(string title)
        {
            try
            {
                var photos = _context.Photos.FirstOrDefault(p => p.Title == title);
                _response.Data = photos;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }




        /*
        [HttpGet("GetPhoto/{id}")]
        public ResponseDto GetPhotoById(int id)
        {
            try
            {
                IEnumerable<AtlasPhoto> photos = _context.Photos.ToList();
                if (photos != null && photos.Any())
                {
                    _response.Data = photos;
                }
                else
                {
                    _response.IsSuccess = false;
                    _response.Message = "No photos found.";
                }
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }
        */


    }
}
