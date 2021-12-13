export class StoryNode {
    public Id: number;
    public Name: string;
    public Description: string;
    public ChildNodes: StoryNode[] = [];
}

export class Story
{
    public StoryId: number;
    public Name: string;
    public Description: string;
    public RootNode: StoryNode;
}