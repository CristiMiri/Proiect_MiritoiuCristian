using Server.Domain.Model;
using System;
using System.Collections.Generic;

namespace Server.Domain.DTO
{
    internal class PresentationDTO
    {
        public int Id { get;  set; }
        public string Title { get;  set; }
        public string Description { get;  set; }
        public DateTime Date { get;  set; }
        public TimeSpan Hour { get;  set; }
        public Section Section { get;  set; }
        public int IdConference { get;  set; }
        public int IdAuthor { get;  set; }
        public List<ParticipantDTO> Participants { get;  set; }
        public List<ParticipantDTO> Author { get;  set; }

        // Default constructor made private to enforce the use of the builder
        private PresentationDTO() { }

        // Constructor to initialize the DTO from a Presentation entity
        public PresentationDTO(Presentation presentation)
        {
            Id = presentation.Id;
            Title = presentation.Title;
            Description = presentation.Description;
            Date = presentation.Date;
            Hour = presentation.Hour;
            Section = presentation.Section;
            IdConference = presentation.IdConference;
            IdAuthor = presentation.IdAuthor;
            Participants = ParticipantDTO.FromParticipantList(presentation.Participants);
            Author = ParticipantDTO.FromParticipantList(presentation.Author);
        }

        public PresentationDTO(int id, string title, string description, DateTime date, TimeSpan hour, Section section, int idConference, int idAuthor, List<ParticipantDTO> participants, List<ParticipantDTO> author)
        {
            Id = id;
            Title = title;
            Description = description;
            Date = date;
            Hour = hour;
            Section = section;
            IdConference = idConference;
            IdAuthor = idAuthor;
            Participants = participants;
            Author = author;
        }

        public override string ToString()
        {
            return $"PresentationDTO with id {Id} and title {Title}, description: {Description}, date: {Date}, hour: {Hour}, section: {Section}, conference id: {IdConference}, author id: {IdAuthor}";
        }

        // Converts a list of Presentation entities to a list of PresentationDTOs
        public static List<PresentationDTO> FromPresentationList(List<Presentation> presentations)
        {
            var presentationDTOs = new List<PresentationDTO>();
            foreach (var presentation in presentations)
            {
                presentationDTOs.Add(new PresentationDTO(presentation));
            }
            return presentationDTOs;
        }

        // Builder class
        public class Builder
        {
            private readonly PresentationDTO _presentationDTO;

            public Builder()
            {
                _presentationDTO = new PresentationDTO();
            }

            public Builder SetId(int id)
            {
                _presentationDTO.Id = id;
                return this;
            }

            public Builder SetTitle(string title)
            {
                _presentationDTO.Title = title;
                return this;
            }

            public Builder SetDescription(string description)
            {
                _presentationDTO.Description = description;
                return this;
            }

            public Builder SetDate(DateTime date)
            {
                _presentationDTO.Date = date;
                return this;
            }

            public Builder SetHour(TimeSpan hour)
            {
                _presentationDTO.Hour = hour;
                return this;
            }

            public Builder SetSection(Section section)
            {
                _presentationDTO.Section = section;
                return this;
            }

            public Builder SetIdConference(int idConference)
            {
                _presentationDTO.IdConference = idConference;
                return this;
            }

            public Builder SetIdAuthor(int idAuthor)
            {
                _presentationDTO.IdAuthor = idAuthor;
                return this;
            }

            public Builder SetParticipants(List<ParticipantDTO> participants)
            {
                _presentationDTO.Participants = participants;
                return this;
            }

            public Builder SetAuthor(List<ParticipantDTO> author)
            {
                _presentationDTO.Author = author;
                return this;
            }

            public PresentationDTO Build()
            {
                return _presentationDTO;
            }
        }
    }
}
