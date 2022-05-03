// #nullable disable
// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Aspose.Words;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.AspNetCore.Mvc.Rendering;
// using Microsoft.EntityFrameworkCore;
// using PetTransport.Domain;
// using PetTransport.Domain.Entities;
// using PetTransport.Infrastructure.Data;
// using Syncfusion.DocIO;
// using Syncfusion.DocIO.DLS;
// using OutlineLevel = Aspose.Words.OutlineLevel;
//
// namespace PetTransport.Web.Controllers
// {
//     public class OrderController : Controller
//     {
//         private readonly ApplicationDbContext _context;
//
//         public OrderController(ApplicationDbContext context)
//         {
//             _context = context;
//         }
//
//         // GET: Order
//         public async Task<IActionResult> Index()
//         {
//             return View(await _context.Orders.ToListAsync());
//         }
//
//         // GET: Order/Details/5
//         public async Task<IActionResult> Details(Guid? id)
//         {
//             if (id == null)
//             {
//                 return NotFound();
//             }
//
//             var order = await _context.Orders
//                 .FirstOrDefaultAsync(m => m.Id == id);
//             if (order == null)
//             {
//                 return NotFound();
//             }
//
//             return View(order);
//         }
//
//         // GET: Order/Create
//         public IActionResult Create()
//         {
//             return View();
//         }
//
//         // POST: Order/Create
//         // To protect from overposting attacks, enable the specific properties you want to bind to.
//         // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//         [HttpPost]
//         public async Task<IActionResult> Create(
//             [Bind(
//                 "Id,CountryOfDestination,DepartureDate,Price,Airport,RailwayStation,Courier,Address,TransferPhoneNumber,ShelterFrom,SenderFullName,SenderStreet,SenderCity,SenderRegion,Zip,SenderPhoneNumber,SenderEmail,SenderWhatsApp,Name,Breed,Sex,Color,DateOfBirth,ChipNumber,DateOfChip,RecipientFullName,RecipientStreet,RecipientZip,RecipientPhoneNumber,RecipientEmail,RecipientWhatsApp")]
//             Order order)
//         {
//             if (ModelState.IsValid)
//             {
//                 order.Id = Guid.NewGuid();
//                 _context.Add(order);
//                 await _context.SaveChangesAsync();
//                 return RedirectToAction(nameof(Index));
//             }
//
//             return View(order);
//         }
//
//         // GET: Order/Edit/5
//         public async Task<IActionResult> Edit(Guid? id)
//         {
//             if (id == null)
//             {
//                 return NotFound();
//             }
//
//             var order = await _context.Orders.FindAsync(id);
//             if (order == null)
//             {
//                 return NotFound();
//             }
//
//             return View(order);
//         }
//
//         // POST: Order/Edit/5
//         // To protect from overposting attacks, enable the specific properties you want to bind to.
//         // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//         [HttpPost]
//         [ValidateAntiForgeryToken]
//         public async Task<IActionResult> Edit(Guid id,
//             [Bind(
//                 "Id,CountryOfDestination,DepartureDate,Price,Airport,RailwayStation,Courier,Address,TransferPhoneNumber,ShelterFrom,SenderFullName,SenderStreet,SenderCity,SenderRegion,Zip,SenderPhoneNumber,SenderEmail,SenderWhatsApp,Name,Breed,Sex,Color,DateOfBirth,ChipNumber,DateOfChip,RecipientFullName,RecipientStreet,RecipientZip,RecipientPhoneNumber,RecipientEmail,RecipientWhatsApp")]
//             Order order)
//         {
//             if (id != order.Id)
//             {
//                 return NotFound();
//             }
//
//             if (ModelState.IsValid)
//             {
//                 try
//                 {
//                     _context.Update(order);
//                     await _context.SaveChangesAsync();
//                 }
//                 catch (DbUpdateConcurrencyException)
//                 {
//                     if (!OrderExists(order.Id))
//                     {
//                         return NotFound();
//                     }
//                     else
//                     {
//                         throw;
//                     }
//                 }
//
//                 return RedirectToAction(nameof(Index));
//             }
//
//             return View(order);
//         }
//
//         // GET: Order/Delete/5
//         public async Task<IActionResult> Delete(Guid? id)
//         {
//             if (id == null)
//             {
//                 return NotFound();
//             }
//
//             var order = await _context.Orders
//                 .FirstOrDefaultAsync(m => m.Id == id);
//             if (order == null)
//             {
//                 return NotFound();
//             }
//
//             return View(order);
//         }
//
//         // POST: Order/Delete/5
//         [HttpPost, ActionName("Delete")]
//         [ValidateAntiForgeryToken]
//         public async Task<IActionResult> DeleteConfirmed(Guid id)
//         {
//             var order = await _context.Orders.FindAsync(id);
//             _context.Orders.Remove(order);
//             await _context.SaveChangesAsync();
//             return RedirectToAction(nameof(Index));
//         }
//
//
//         // POST: Order/Delete/5
//         [HttpGet]
//         public async Task<IActionResult> Invoice(Guid id)
//         {
//             // Creating a new document.
//             WordDocument document = new WordDocument();
// //Adding a new section to the document.
//             WSection section = document.AddSection() as WSection;
// //Set Margin of the section
//             section.PageSetup.Margins.All = 72;
// //Set page size of the section
//             section.PageSetup.PageSize = new Syncfusion.Drawing.SizeF(612, 792);
//
// //Create Paragraph styles
//             WParagraphStyle style = document.AddParagraphStyle("Normal") as WParagraphStyle;
//             style.CharacterFormat.FontName = "Calibri";
//             style.CharacterFormat.FontSize = 11f;
//             style.ParagraphFormat.BeforeSpacing = 0;
//             style.ParagraphFormat.AfterSpacing = 8;
//             style.ParagraphFormat.LineSpacing = 13.8f;
//
//             style = document.AddParagraphStyle("Heading 1") as WParagraphStyle;
//             style.ApplyBaseStyle("Normal");
//             style.CharacterFormat.FontName = "Calibri Light";
//             style.CharacterFormat.FontSize = 16f;
//             style.CharacterFormat.TextColor = Syncfusion.Drawing.Color.FromArgb(46, 116, 181);
//             style.ParagraphFormat.BeforeSpacing = 12;
//             style.ParagraphFormat.AfterSpacing = 0;
//             style.ParagraphFormat.Keep = true;
//             style.ParagraphFormat.KeepFollow = true;
//             IWParagraph paragraph = section.HeadersFooters.Header.AddParagraph();
//
// // Gets the image stream.
//
//
//             paragraph.ApplyStyle("Normal");
//             paragraph.ParagraphFormat.HorizontalAlignment = HorizontalAlignment.Left;
//             WTextRange textRange = paragraph.AppendText("Adventure Works Cycles") as WTextRange;
//             textRange.CharacterFormat.FontSize = 12f;
//             textRange.CharacterFormat.FontName = "Calibri";
//             textRange.CharacterFormat.TextColor = Syncfusion.Drawing.Color.Red;
//
// //Appends paragraph.
//             paragraph = section.AddParagraph();
//             paragraph.ApplyStyle("Heading 1");
//             paragraph.ParagraphFormat.HorizontalAlignment = HorizontalAlignment.Center;
//             textRange = paragraph.AppendText("Adventure Works Cycles") as WTextRange;
//             textRange.CharacterFormat.FontSize = 18f;
//             textRange.CharacterFormat.FontName = "Calibri";
//
// //Appends paragraph.
//             paragraph = section.AddParagraph();
//             paragraph.ParagraphFormat.FirstLineIndent = 36;
//             paragraph.BreakCharacterFormat.FontSize = 12f;
//             textRange = paragraph.AppendText(
//                     "Adventure Works Cycles, the fictitious company on which the AdventureWorks sample databases are based, is a large, multinational manufacturing company. The company manufactures and sells metal and composite bicycles to North American, European and Asian commercial markets. While its base operation is in Bothell, Washington with 290 employees, several regional sales teams are located throughout their market base.")
//                 as WTextRange;
//             textRange.CharacterFormat.FontSize = 12f;
//
// //Appends paragraph.
//             paragraph = section.AddParagraph();
//             paragraph.ParagraphFormat.FirstLineIndent = 36;
//             paragraph.BreakCharacterFormat.FontSize = 12f;
//             textRange = paragraph.AppendText(
//                     "In 2000, AdventureWorks Cycles bought a small manufacturing plant, Importadores Neptuno, located in Mexico. Importadores Neptuno manufactures several critical subcomponents for the AdventureWorks Cycles product line. These subcomponents are shipped to the Bothell location for final product assembly. In 2001, Importadores Neptuno, became the sole manufacturer and distributor of the touring bicycle product group.")
//                 as WTextRange;
//             textRange.CharacterFormat.FontSize = 12f;
//
//             paragraph = section.AddParagraph();
//             paragraph.ApplyStyle("Heading 1");
//             paragraph.ParagraphFormat.HorizontalAlignment = HorizontalAlignment.Left;
//             textRange = paragraph.AppendText("Product Overview") as WTextRange;
//             textRange.CharacterFormat.FontSize = 16f;
//             textRange.CharacterFormat.FontName = "Calibri";
// //Appends table.
//             IWTable table = section.AddTable();
//             table.ResetCells(3, 2);
//             table.TableFormat.Borders.BorderType = BorderStyle.None;
//             table.TableFormat.IsAutoResized = true;
//
// //Appends paragraph.
//             paragraph = table[0, 0].AddParagraph();
//             paragraph.ParagraphFormat.AfterSpacing = 0;
//             paragraph.BreakCharacterFormat.FontSize = 12f;
// //Appends picture to the paragraph.
//
// //Appends paragraph.
//             paragraph = table[0, 1].AddParagraph();
//             paragraph.ApplyStyle("Heading 1");
//             paragraph.ParagraphFormat.AfterSpacing = 0;
//             paragraph.ParagraphFormat.LineSpacing = 12f;
//             paragraph.AppendText("Mountain-200");
// //Appends paragraph.
//             paragraph = table[0, 1].AddParagraph();
//             paragraph.ParagraphFormat.AfterSpacing = 0;
//             paragraph.ParagraphFormat.LineSpacing = 12f;
//             paragraph.BreakCharacterFormat.FontSize = 12f;
//             paragraph.BreakCharacterFormat.FontName = "Times New Roman";
//
//             textRange = paragraph.AppendText("Product No: BK-M68B-38\r") as WTextRange;
//             textRange.CharacterFormat.FontSize = 12f;
//             textRange.CharacterFormat.FontName = "Times New Roman";
//             textRange = paragraph.AppendText("Size: 38\r") as WTextRange;
//             textRange.CharacterFormat.FontSize = 12f;
//             textRange.CharacterFormat.FontName = "Times New Roman";
//             textRange = paragraph.AppendText("Weight: 25\r") as WTextRange;
//             textRange.CharacterFormat.FontSize = 12f;
//             textRange.CharacterFormat.FontName = "Times New Roman";
//             textRange = paragraph.AppendText("Price: $2,294.99\r") as WTextRange;
//             textRange.CharacterFormat.FontSize = 12f;
//             textRange.CharacterFormat.FontName = "Times New Roman";
// //Appends paragraph.
//             paragraph = table[0, 1].AddParagraph();
//             paragraph.ParagraphFormat.AfterSpacing = 0;
//             paragraph.ParagraphFormat.LineSpacing = 12f;
//             paragraph.BreakCharacterFormat.FontSize = 12f;
//
// //Appends paragraph.
//             paragraph = table[1, 0].AddParagraph();
//             paragraph.ApplyStyle("Heading 1");
//             paragraph.ParagraphFormat.AfterSpacing = 0;
//             paragraph.ParagraphFormat.LineSpacing = 12f;
//             paragraph.AppendText("Mountain-300 ");
// //Appends paragraph.
//             paragraph = table[1, 0].AddParagraph();
//             paragraph.ParagraphFormat.AfterSpacing = 0;
//             paragraph.ParagraphFormat.LineSpacing = 12f;
//             paragraph.BreakCharacterFormat.FontSize = 12f;
//             paragraph.BreakCharacterFormat.FontName = "Times New Roman";
//             textRange = paragraph.AppendText("Product No: BK-M47B-38\r") as WTextRange;
//             textRange.CharacterFormat.FontSize = 12f;
//             textRange.CharacterFormat.FontName = "Times New Roman";
//             textRange = paragraph.AppendText("Size: 35\r") as WTextRange;
//             textRange.CharacterFormat.FontSize = 12f;
//             textRange.CharacterFormat.FontName = "Times New Roman";
//             textRange = paragraph.AppendText("Weight: 22\r") as WTextRange;
//             textRange.CharacterFormat.FontSize = 12f;
//             textRange.CharacterFormat.FontName = "Times New Roman";
//             textRange = paragraph.AppendText("Price: $1,079.99\r") as WTextRange;
//             textRange.CharacterFormat.FontSize = 12f;
//             textRange.CharacterFormat.FontName = "Times New Roman";
// //Appends paragraph.
//             paragraph = table[1, 0].AddParagraph();
//             paragraph.ParagraphFormat.AfterSpacing = 0;
//             paragraph.ParagraphFormat.LineSpacing = 12f;
//             paragraph.BreakCharacterFormat.FontSize = 12f;
//
// //Appends paragraph.
//             paragraph = table[1, 1].AddParagraph();
//             paragraph.ApplyStyle("Heading 1");
//             paragraph.ParagraphFormat.LineSpacing = 12f;
// //Appends picture to the paragraph.
//
// //Appends paragraph.
//             paragraph = table[2, 0].AddParagraph();
//             paragraph.ApplyStyle("Heading 1");
//             paragraph.ParagraphFormat.LineSpacing = 12f;
// //Appends picture to the paragraph.
//
//
// //Appends paragraph.
//             paragraph = table[2, 1].AddParagraph();
//             paragraph.ApplyStyle("Heading 1");
//             paragraph.ParagraphFormat.AfterSpacing = 0;
//             paragraph.ParagraphFormat.LineSpacing = 12f;
//             paragraph.AppendText("Road-150 ");
// //Appends paragraph.
//             paragraph = table[2, 1].AddParagraph();
//             paragraph.ParagraphFormat.AfterSpacing = 0;
//             paragraph.ParagraphFormat.LineSpacing = 12f;
//             paragraph.BreakCharacterFormat.FontSize = 12f;
//             paragraph.BreakCharacterFormat.FontName = "Times New Roman";
//             textRange = paragraph.AppendText("Product No: BK-R93R-44\r") as WTextRange;
//             textRange.CharacterFormat.FontSize = 12f;
//             textRange.CharacterFormat.FontName = "Times New Roman";
//             textRange = paragraph.AppendText("Size: 44\r") as WTextRange;
//             textRange.CharacterFormat.FontSize = 12f;
//             textRange.CharacterFormat.FontName = "Times New Roman";
//             textRange = paragraph.AppendText("Weight: 14\r") as WTextRange;
//             textRange.CharacterFormat.FontSize = 12f;
//             textRange.CharacterFormat.FontName = "Times New Roman";
//             textRange = paragraph.AppendText("Price: $3,578.27\r") as WTextRange;
//             textRange.CharacterFormat.FontSize = 12f;
//             textRange.CharacterFormat.FontName = "Times New Roman";
// //Appends paragraph.
//             section.AddParagraph();
//
// //Saves the Word document to  MemoryStream
//             MemoryStream stream = new MemoryStream();
//             document.Save(stream, FormatType.Docx);
//             stream.Position = 0;
//
// //Download Word document in the browser
//             return File(stream, "application/msword", "Sample.docx");
//         }
//
//         private bool OrderExists(Guid id)
//         {
//             return _context.Orders.Any(e => e.Id == id);
//         }
//     }
// }
