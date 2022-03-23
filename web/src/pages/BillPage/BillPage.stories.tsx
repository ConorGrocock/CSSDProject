import React from 'react';

import {ComponentMeta, ComponentStory} from '@storybook/react';
import BillPage from "./BillPage";

export default {
    title: 'Pages/BillPage',
    component: BillPage,
    argTypes: {},
    parameters: {
        layout: "fullscreen"
    }
} as ComponentMeta<typeof BillPage>;

const Template: ComponentStory<typeof BillPage> = ({...args}) => {
    return <BillPage {...args} />;
};

export const Default = Template.bind({});