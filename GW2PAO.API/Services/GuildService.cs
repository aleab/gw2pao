﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GW2DotNET;
using GW2PAO.API.Data;
using GW2PAO.API.Services.Interfaces;
using NLog;

namespace GW2PAO.API.Services
{
    public class GuildService : IGuildService
    {
        /// <summary>
        /// Default logger
        /// </summary>
        private static Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// The GW2.NET API service object
        /// </summary>
        private ServiceManager service = new ServiceManager();

        /// <summary>
        /// Retrieves guild information using the given guild ID
        /// </summary>
        /// <param name="id">The guild's guild ID</param>
        /// <returns>the guild's information</returns>
        public Guild GetGuild(Guid id)
        {
            logger.Debug("Retrieving guild information for {0}", id);

            Guild guild = null;

            var details = this.service.GetGuildDetailsById(id);
            if (details != null)
            {
                guild = new Guild(id)
                {
                    Name = details.Name,
                    Tag = details.Tag
                };
            }

            return guild;
        }

        /// <summary>
        /// Retrieves guild information using the given guild name
        /// </summary>
        /// <param name="name">The guild's name</param>
        /// <returns>the guild's information</returns>
        public Guild GetGuild(string name)
        {
            logger.Debug("Retrieving guild information for \"{0}\"", name);

            Guild guild = null;

            var details = this.service.GetGuildDetailsByName(name);
            if (details != null)
            {
                guild = new Guild(details.GuildId)
                {
                    Name = details.Name,
                    Tag = details.Tag
                };
            }

            return guild;
        }
    }
}
