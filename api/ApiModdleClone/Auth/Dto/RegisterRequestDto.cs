using System.ComponentModel.DataAnnotations;

public class RegisterRequestDto
{
    public int Email { get; set; }

    public int Username { get; set; }

    [Required]
    [StringLength(100)]
    public string Password { get; set; } = null!;
}
