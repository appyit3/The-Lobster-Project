export class StoryNode {
    public Id: number;
    public Name: string;
    public Description: string;
    public ChildNodes: { [key: number]: Story; }[] = [];
}

export class Story
{
    public StoryId: number;
    public Name: string;
    public Description: string;
    public RootNode: StoryNode;
}