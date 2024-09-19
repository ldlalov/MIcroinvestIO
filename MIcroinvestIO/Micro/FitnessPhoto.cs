using System;
using System.Collections.Generic;

namespace MIcroinvestIO.Micro;

public partial class FitnessPhoto
{
    public int FitnessPhotoId { get; set; }

    public int PartnerId { get; set; }

    public byte[] ImageData { get; set; } = null!;
}
