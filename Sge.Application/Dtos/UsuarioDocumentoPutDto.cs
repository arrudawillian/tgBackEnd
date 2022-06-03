﻿using Sge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sge.Application.Dtos
{
    public class UsuarioDocumentoPutDto
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public string Titulo { get; set; }
        public string Path { get; set; }
        public int DocumentoId { get; set; }
        public int StatusId { get; set; }
        public bool Excluido { get; set; }
    }
}
