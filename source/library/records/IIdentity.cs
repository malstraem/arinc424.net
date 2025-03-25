namespace Arinc424;

/**<summary>
An entity that has an identifier that is not necessarily unique.
</summary>*/
public interface IIdentity
{
    string Identifier { get; set; }
}
