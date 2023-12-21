using DSED_Module6_CompteBanquaire.Models;
using DSED_Module6_Entite;
using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;
using RabbitMQ.Client;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DSED_Module6_CompteBanquaire.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompteController : ControllerBase
    {
        private ManipulationEntite m_manipulationEntite;
        public CompteController(ManipulationEntite p_manipulationEntite)
        {
            m_manipulationEntite = p_manipulationEntite;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        public ActionResult<IEnumerable<CompteModel>> Get()
        {
            return Ok(m_manipulationEntite.GetToutLesComptes());
        }
     
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult<CompteModel> Get(int id)
        {
            if(m_manipulationEntite.GetCompte(id) == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(m_manipulationEntite.GetCompte(id));
            }
        }

        [HttpGet("{compteId}/{transactionId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult<CompteModel> Get(int compteId, int transactionId)
        {
            if (m_manipulationEntite.GetCompte(compteId) == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(m_manipulationEntite.GetCompte(compteId));
            }
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public ActionResult Post([FromBody] CompteModel p_compteModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            Compte compte = p_compteModel.VersEntite();
            string jsonClient = Newtonsoft.Json.JsonConvert.SerializeObject(compte);
            ConnectionFactory factory = new ConnectionFactory() { HostName = "localhost" };
            using (IConnection connexion = factory.CreateConnection())
            {
                using (RabbitMQ.Client.IModel channel = connexion.CreateModel())
                {
                    channel.QueueDeclare(queue: "compte",
                    durable: false,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null
                    );

                    byte[] body = Encoding.UTF8.GetBytes(jsonClient);

                    channel.BasicPublish(exchange: "", routingKey: "client", body: body);
                }
            }
            return CreatedAtAction(nameof(Get), new { id = p_compteModel.CompteId }, p_compteModel);
        }

        // PUT api/<ValuesController1>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController1>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
