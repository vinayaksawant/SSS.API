using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SSS.API.Data;
using SSS.API.Models.Domain;
using SSS.API.Repositories.Implementaion;

namespace SSS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentsController : ControllerBase
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly ApplicationDbContext dbContext;

        public DocumentsController(IWebHostEnvironment webHostEnvironment,
            IHttpContextAccessor httpContextAccessor, ApplicationDbContext dbContext)
        {
            this.webHostEnvironment = webHostEnvironment;
            this.httpContextAccessor = httpContextAccessor;
            this.dbContext = dbContext;
        }
        /*
        // GET: api/Documents
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Document>>> GetDocuments()
        {
          if (_context.Documents == null)
          {
              return NotFound();
          }
            return await _context.Documents.ToListAsync();
        }

        // GET: api/Documents/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Document>> GetDocument(Guid id)
        {
          if (_context.Documents == null)
          {
              return NotFound();
          }
            var document = await _context.Documents.FindAsync(id);

            if (document == null)
            {
                return NotFound();
            }

            return document;
        }

        // PUT: api/Documents/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDocument(Guid id, Document document)
        {
            if (id != document.Id)
            {
                return BadRequest();
            }

            _context.Entry(document).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DocumentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Documents
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Document>> PostDocument(Document document)
        //{
        //  if (_context.Documents == null)
        //  {
        //      return Problem("Entity set 'ApplicationDbContext.Documents'  is null.");
        //  }
        //    _context.Documents.Add(document);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetDocument", new { id = document.Id }, document);
        //}
        */
        // POST: {apibaseurl}/api/Documents
        [HttpPost]
        public async Task<IActionResult> UploadDocument([FromForm] IFormFile file,
            [FromForm] string fileName, [FromForm] string title, [FromForm] string fileType)
        {
            ValidateFileUpload(file);

            if (ModelState.IsValid)
            {
                // File upload
                var documentFile = new Document
                {
                    DocumentExtension = Path.GetExtension(file.FileName).ToLower(),
                    DocumentName = fileName,
                    DocumentTitle = title,
                    DocumentUrl = "",
                    DocumentType = fileType,
                    DateCreated = DateTime.Now
                };

                documentFile = await this.Upload(file, documentFile);

                // Convert Domain Model to DTO
                //var response = new BlogImageDto
                //{
                //    Id = blogImage.Id,
                //    Title = blogImage.Title,
                //    DateCreated = blogImage.DateCreated,
                //    FileExtension = blogImage.FileExtension,
                //    FileName = blogImage.FileName,
                //    Url = blogImage.Url
                //};

                return Ok(documentFile);
            }

            return BadRequest(ModelState);
        }

        private async Task<Document> Upload(IFormFile file, Document documentFile)
        {
            // 1- Upload the Image to API/Images
            var localPath = Path.Combine(webHostEnvironment.ContentRootPath, "Images", $"{documentFile.DocumentName}{documentFile.DocumentExtension}");
            using var stream = new FileStream(localPath, FileMode.Create);
            await file.CopyToAsync(stream);

            // 2-Update the database
            // https://codepulse.com/images/somefilename.jpg
            var httpRequest = httpContextAccessor.HttpContext.Request;
            var urlPath = $"{httpRequest.Scheme}://{httpRequest.Host}{httpRequest.PathBase}/Images/{documentFile.DocumentName}{documentFile.DocumentExtension}";

            documentFile.DocumentUrl = urlPath;

            await dbContext.Documents.AddAsync(documentFile);
            await dbContext.SaveChangesAsync();

            return documentFile;
        }

        private void ValidateFileUpload(IFormFile file)
        {
            var allowedExtensions = new string[] { ".jpg", ".jpeg", ".png", ".ico", ".txt" };

            if (!allowedExtensions.Contains(Path.GetExtension(file.FileName).ToLower()))
            {
                ModelState.AddModelError("file", "Unsupported file format");
            }

            if (file.Length > 10485760)
            {
                ModelState.AddModelError("file", "File size cannot be more than 10MB");
            }
        }

        /*
        // DELETE: api/Documents/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDocument(Guid id)
        {
            if (_context.Documents == null)
            {
                return NotFound();
            }
            var document = await _context.Documents.FindAsync(id);
            if (document == null)
            {
                return NotFound();
            }

            _context.Documents.Remove(document);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DocumentExists(Guid id)
        {
            return (_context.Documents?.Any(e => e.Id == id)).GetValueOrDefault();
        }
        */
    }
}
