using Godot;
using System;

public class ModuleLocationButton : Control
{
    

    private ShipModule module;

    //[Export(PropertyHint.Range, "0,4")]
    //public int sectionLocation;
    //[Export(PropertyHint.Range, "0,5")]
    //public int moduleLocation;

    private ShipLocation location;

    public ShipLocation Location { get => location; set{ location = value; Refresh();}}

    private void Refresh()
    {
        module = Homecomer.getModule(Location);

        string textureName  = "";
        switch(module.ModuleType){
            case ModuleType.armoury:
                textureName = "Armoury";
                break;
            case ModuleType.atrium:
                textureName = "Atrium";
                break;
            case ModuleType.cargo_area:
                textureName = "Storage";
                break;
            case ModuleType.clinic:
                textureName = "Clinic";
                break;
            case ModuleType.habitat:
                textureName = "Habitat";
                break;
            case ModuleType.hangar:
                textureName = "Hangar";
                break;
            case ModuleType.hydroponics:
                textureName = "Hydroponics";
                break;
            case ModuleType.laboratory:
                textureName = "Laboratory";
                break;
            case ModuleType.library:
                textureName = "Library";
                break;
            case ModuleType.morge:
                textureName = "Morge";
                break;
            case ModuleType.rec_area:
                textureName = "Rec area";
                break;
            case ModuleType.soc_area:
                textureName = "Social area";
                break;
            case ModuleType.workshop:
                textureName = "Workshop";
                break;
            default:
                textureName = "Empty";
                break;
        }
        Texture tex = GD.Load<Texture>("res://UI/module_types/" + textureName + ".png");
        Button btn = (Button)GetNode(new NodePath("Button"));
        btn.Icon = tex;
        btn.HintTooltip = Location + " - " + module.ModuleType;
    }

    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {

    }

    [Signal]
    public delegate void ModuleSelected(int s, int m);//(ShipLocation location);

    public void _on_Button_pressed()
    {
        //GD.Print("Hello button");
        EmitSignal(nameof(ModuleSelected), Location.S, Location.M);
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
